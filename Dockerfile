#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . . 
#RUN dotnet restore "Consumer/tests/tests.csproj" --disable-parallel
#RUN dotnet test "Consumer/tests/tests.csproj" --no-restore

RUN dotnet test "Consumer/tests/tests.csproj" 
RUN dotnet test "Provider/tests/tests.csproj" 

ENTRYPOINT ["/bin/sh"] 
#ENTRYPOINT ["dotnet", "test", "Provider/tests/tests.csproj"] 

#NOTES
#dotnet test Consumer/tests/tests.csproj
#dotnet test Provider/tests/tests.csproj
# docker build . -t pact-net-provider-test --progress=plain

