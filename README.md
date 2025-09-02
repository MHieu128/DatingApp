# DatingApp

This repository contains a full-stack dating application with a .NET (ASP.NET Core) backend and an Angular frontend.

## Project Structure

- **Backend/**: Contains the ASP.NET Core Web API project.
  - `DatingApi/`: Main backend project folder
    - `Controllers/`: API controllers
    - `Data/`: Database context and migrations
    - `Entities/`: Entity models
    - `Program.cs`: Entry point
    - `appsettings.json`: Configuration files
- **Frontend/DatingWeb/**: Contains the Angular frontend project.
  - `src/`: Angular source code
  - `public/`: Static assets

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/)
- [Node.js & npm](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)

### Backend Setup
1. Navigate to the backend directory:
   ```sh
   cd Backend/DatingApi
   ```
2. Restore dependencies and run migrations:
   ```sh
   dotnet restore
   dotnet ef database update
   ```
3. Run the API:
   ```sh
   dotnet run
   ```

### Frontend Setup
1. Navigate to the frontend directory:
   ```sh
   cd Frontend/DatingWeb
   ```
2. Install dependencies:
   ```sh
   npm install
   ```
3. Run the Angular app:
   ```sh
   ng serve
   ```

## License

This project is licensed under the MIT License.
