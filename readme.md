## Requirement 
 1. c#
 2. Docker
 3. MOngoDB
 4. MongoDB For visualstudio
 5. PostMan
## Adding MongoDB PAckage
`dotnet add package MongoDB.Driver`
## Running mondo db in a docker container
1. For v1 `docker run -d --rm --name  mongo -p 27017:27017 -v mongodbdata:/data/db mongo`
## Setting up on Windows
## Resources
1. [https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows](url)
    1. `dotnet user-secrets set "MongoDbSettings:Password" "Pass#word1"`
2. Password: Pass#word1