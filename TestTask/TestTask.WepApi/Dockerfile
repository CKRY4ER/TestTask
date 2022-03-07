#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TestTask.WepApi/TestTask.WepApi.csproj", "TestTask.WepApi/"]
COPY ["TestTask.Persistence/TestTask.Persistence.csproj", "TestTask.Persistence/"]
COPY ["TestTask.Application/TestTask.Application.csproj", "TestTask.Application/"]
COPY ["TestTask.Domain/TestTask.Domain.csproj", "TestTask.Domain/"]
RUN dotnet restore "TestTask.WepApi/TestTask.WepApi.csproj"
COPY . .
WORKDIR "/src/TestTask.WepApi"
RUN dotnet build "TestTask.WepApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTask.WepApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTask.WepApi.dll"]