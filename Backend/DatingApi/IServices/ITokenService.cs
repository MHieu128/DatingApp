using DatingApi.Entities;

namespace DatingApi.IServices;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
