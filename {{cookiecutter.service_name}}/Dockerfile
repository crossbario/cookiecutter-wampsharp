#
# stage 1: build target app
#
FROM microsoft/dotnet:sdk AS build-env
WORKDIR /build

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build everything
# in the "out" directory
COPY . ./
RUN dotnet publish -c Release -o out

#
# stage 2: build runtime image
#
FROM microsoft/dotnet:runtime
COPY --from=build-env /build/out /client

WORKDIR /client
CMD ["/usr/bin/dotnet", "MyService.dll"]
