# https://github.com/dotnet/dotnet-docker/issues/2375
# https://hub.docker.com/_/microsoft-dotnet-sdk
# best practice: Use Small-Sized Official Images(alpine)
FROM mcr.microsoft.com/dotnet/sdk:6.0.302-alpine3.16-amd64 AS build-env
WORKDIR /source
COPY ./ .
RUN dotnet restore
RUN dotnet publish -c Release -o /publish

####################################################
# https://hub.docker.com/_/microsoft-dotnet-aspnet
# best practice: Use Small-Sized Official Images(alpine)
FROM mcr.microsoft.com/dotnet/aspnet:6.0.7-alpine3.16-amd64

# Install timezone data.
RUN apk update && apk add tzdata

# https://stackoverflow.com/questions/49955097/how-do-i-add-a-user-when-im-using-alpine-as-a-base-image
# adduser
# -S              Create a system user
# -G GRP          Group
# Create a group and user
# https://unix.stackexchange.com/questions/80277/whats-the-difference-between-a-normal-user-and-a-system-user
RUN addgroup -S --gid 1001 cqi && adduser -S -u1001 -g1001 cqi

WORKDIR /publish

# set ownership and permissions
# https://linux.die.net/man/1/chown
RUN chown -R cqi:cqi /publish

# https://github.com/dotnet/aspnetcore/issues/4699
ENV ASPNETCORE_URLS=http://*:8080

# Tell docker that all future commands should run as the cqi user
USER cqi

COPY --chown=cqi:cqi --from=build-env /publish .

ENTRYPOINT ["dotnet", "SnakeAsianLeague.dll"]