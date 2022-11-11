FROM mcr.microsoft.com/dotnet/sdk:6.0-focal as dev

RUN mkdir /work/
WORKDIR /work

COPY ./PostAPI/PostAPI.csproj /work/PostAPI.csproj
RUN dotnet restore

COPY ./PostAPI /work
RUN mkdir /out/

RUN dotnet publish --no-restore --output /out --configuration Release 


FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal as prod

RUN mkdir /app/
WORKDIR /app/

copy --from=dev /out/  /app/

RUN chmod +x /app/ 
CMD dotnet work.dll
