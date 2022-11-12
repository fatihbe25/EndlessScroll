# Build Stage

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS  build

WORKDIR /source

COPY . .

RUN dotnet restore "./PostAPI/PostAPI.csproj" --disable-parallel
RUN dotnet publish "./PostAPI/PostAPI.csproj" -c release -o /app --no-restore 

# Serve Stage 

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal

WORKDIR /app

COPY --from=build /app ./

EXPOSE 5000

RUN chmod +x /app/
ENTRYPOINT ["dotnet", "PostAPI.dll"]

