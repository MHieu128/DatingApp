using DatingApi.Data;
using DatingApi.DTOs;
using DatingApi.Entities;
using DatingApi.Extensions;
using DatingApi.IServices;
using DatingApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DatingApi.Controllers;

public class AccountController(AppDbContext context, ITokenService tokenService) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
    {
        if (await EmailExists(registerDTO.Email))
        {
            return BadRequest("Email is already taken");
        }

        using var hmac = new HMACSHA512();
        var user = new AppUser
        {
            Email = registerDTO.Email,
            DisplayName = registerDTO.DisplayName,
            PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(registerDTO.Password)),
            PasswordSalt = hmac.Key
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user.ToDTO(tokenService);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Email == loginDTO.Email);
        if (user == null) return Unauthorized("Invalid email");

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(loginDTO.Password));
        if (!computedHash.SequenceEqual(user.PasswordHash)) return Unauthorized("Invalid password");

        return user.ToDTO(tokenService);
    }

    private async Task<bool> EmailExists(string email)
    {
        return await context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
    }

}