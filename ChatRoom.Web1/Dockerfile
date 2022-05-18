#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ChatRoom.Web/ChatRoom.Web.csproj", "ChatRoom.Web/"]
RUN dotnet restore "ChatRoom.Web/ChatRoom.Web.csproj"
COPY . .
WORKDIR "/src/ChatRoom.Web"
RUN dotnet build "ChatRoom.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChatRoom.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatRoom.Web.dll"]