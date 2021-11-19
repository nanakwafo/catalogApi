## Requirement 
 c#
 Docker
 MOngoDB
 MongoDB For visualstudio
 PostMan
## Adding MongoDB PAckage
`dotnet add package MongoDB.Driver`
## Running mondo db in a docker container
`docker run -d --rm --name  mongo -p 27017:27017 -v mongodbdata:/data/db mongo`
## Setting up on Windows
## Setting up on Mac