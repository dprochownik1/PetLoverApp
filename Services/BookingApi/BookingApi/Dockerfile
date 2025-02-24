#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/BookingApi/BookingApi/BookingApi.csproj", "Services/BookingApi/BookingApi/"]
COPY ["Services/BookingApi/Booking.Application/Booking.Application.csproj", "Services/BookingApi/Booking.Application/"]
COPY ["Common.Lib/Common.Lib.csproj", "Common.Lib/"]
COPY ["Services/BookingApi/Booking.Domain/Booking.Domain.csproj", "Services/BookingApi/Booking.Domain/"]
COPY ["Services/BookingApi/Booking.Infrastructure/Booking.Infrastructure.csproj", "Services/BookingApi/Booking.Infrastructure/"]
RUN dotnet restore "./Services/BookingApi/BookingApi/BookingApi.csproj"
COPY . .
WORKDIR "/src/Services/BookingApi/BookingApi"
RUN dotnet build "./BookingApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookingApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingApi.dll"]