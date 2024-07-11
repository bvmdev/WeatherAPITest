# WeatherAPITest
# The Test

Develop an application with a backend and frontend using the C# programming language and Angular. The application should contain an API returning weather forecast data for the next few days. To develop this application, use the 5-day weather forecast API from https://openweathermap.org. You will need to create an account and subscribe to use the API, but it can be done for free. Save the call history in a database for later consultation. The resulting application should be uploaded to your GitHub in a public repository, and the link should be sent to the recruitment team.

Requirements:

Programming language: C# - .NET and Angular.

Container virtualization using Docker.

Develop the endpoints using the REST pattern.

You can use any database you like, but prefer relational databases, such as SQL Server or Oracle.

Use any libraries and frameworks you like (EntityFramework, XUnit, etc.), but the API call must be made directly.

Create a README with at least the instructions for setting up your application's environment.

Include in the repository any artifacts you used to implement this application (Postman collections, unit tests, etc.).

# Pre-Req

.Net Runtime 8.0
.Net SDK 8.0

# Running Entries API

Open de the terminal

Navigate to CSPROJ Directory

Run docker-compose up --build

Open Another Terminal and Navigate to CSPROJ Directory

Run dotnet ef database update

Run dotnet run WeatherForecastApi.csproj

Access the swagger UI from http://localhost:PORT/swagger (port is yout output dotnet run listening on, example: 5172)

