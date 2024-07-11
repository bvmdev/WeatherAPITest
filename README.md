# WeatherAPITest

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

