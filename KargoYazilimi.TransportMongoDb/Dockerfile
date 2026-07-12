# 1. Aþama: Build (Derleme) ve Publish
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Proje dosyasýný kopyalayýp baðýmlýlýklarý yüklüyoruz
COPY ["KargoYazilimi.TransportMongoDb.csproj", "./"]
RUN dotnet restore "./KargoYazilimi.TransportMongoDb.csproj"

# Tüm dosyalarý kopyalayýp projeyi yayýmlýyoruz
COPY . .
RUN dotnet publish "KargoYazilimi.TransportMongoDb.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 2. Aþama: Çalýþtýrma (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 80

# Publish edilen dosyalarý birinci aþamadan alýp buraya kopyalýyoruz
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "KargoYazilimi.TransportMongoDb.dll"]