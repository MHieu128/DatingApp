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
3. (Optional, for HTTPS) Create a local SSL certificate using mkcert:
    - Install [mkcert](https://github.com/FiloSottile/mkcert):
       ```sh
       brew install mkcert
       mkcert -install
       ```
    - Generate certificates in the `ssl` folder:
       ```sh
       mkdir -p ssl
       mkcert -key-file ssl/localhost-key.pem -cert-file ssl/localhost.pem localhost
       ```
    - Update `angular.json` to use the generated certs for `ng serve`:
       ```json
       "serve": {
          "options": {
             "sslKey": "ssl/localhost-key.pem",
             "sslCert": "ssl/localhost.pem"
          }
       }
       ```
    - Then run the Angular app with HTTPS:
       ```sh
       ng serve --ssl true --ssl-key ssl/localhost-key.pem --ssl-cert ssl/localhost.pem
       ```

4. Run the Angular app (HTTP):
    ```sh
    ng serve
    ```

## License

## HTTPS for .NET Backend

To enable HTTPS for the .NET backend in development:

1. Trust the ASP.NET Core development certificate (if not already):
    ```sh
    dotnet dev-certs https --trust
    ```
2. The backend will use HTTPS by default on a random port. You can configure the port in `Properties/launchSettings.json` or via environment variables.

3. If you want to use a custom certificate (e.g., from mkcert), update your `appsettings.Development.json`:
    ```json
    "Kestrel": {
       "Endpoints": {
          "Https": {
             "Url": "https://localhost:5001",
             "Certificate": {
                "Path": "ssl/localhost.pem",
                "KeyPath": "ssl/localhost-key.pem"
             }
          }
       }
    }
    ```
    And ensure the `ssl` folder and certs are accessible to the backend project.

This project is licensed under the MIT License.
