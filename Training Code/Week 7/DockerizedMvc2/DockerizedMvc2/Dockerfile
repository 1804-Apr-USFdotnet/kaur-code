# start with microsoft's asp.net core 2.0 build image
FROM microsoft/aspnetcore-build:2.0 AS build

# "Change directory" in the container to here
WORKDIR /app

# copy csproj as seperate layer for package restore
COPY ./DockerizedMvc2.csproj .
RUN dotnet restore

# copy everything else from the project folder into the container
COPY ./ .

RUN dotnet build --no-restore

FROM build AS test
#RUN dotnet test

FROM build AS package
# sonarqube
RUN dotnet publish -o ./out/

# we don't need build-time deps anymore.
# use asp.net core runtime image (much smaller)
FROM microsoft/aspnetcore:2.0 AS runtime
WORKDIR /app
# copy ONLY what we need from build image, leaving out all the extra stuff in base image
COPY --from=package /app/out/ .

# start the container by running "dotnet DockerizedMvc2.dll"
ENTRYPOINT [ "dotnet", "DockerizedMvc2.dll"]
# CMD [ "dotnet", "run" ]
