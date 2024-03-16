# Используем базовый образ ASP.NET среды выполнения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Устанавливаем PostgreSQL
RUN apt-get update && \
    apt-get install -y postgresql postgresql-contrib && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Добавляем конфигурацию для PostgreSQL
RUN echo "host all all 0.0.0.0/0 md5" >> /etc/postgresql/15/main/pg_hba.conf && \
    echo "listen_addresses = '*'" >> /etc/postgresql/15/main/postgresql.conf && \
    echo "port = 5432" >> /etc/postgresql/15/main/postgresql.conf

# Задаем пароль для пользователя postgres
RUN service postgresql start && \
    su - postgres -c "psql -c \"ALTER USER postgres WITH PASSWORD '1';\"" && \
    su - postgres -c "psql -c \"CREATE DATABASE testd32;\"" && \
    su - postgres -c "psql -c \"GRANT ALL PRIVILEGES ON DATABASE testd32 TO postgres;\""

# Добавляем скрипт для ожидания успешного запуска PostgreSQL
RUN echo -e "#!/bin/bash\n\
\n\
# Ожидаем запуска PostgreSQL\n\
until pg_isready -h localhost -p 5432 -U postgres\n\
do\n\
  echo \"Ждем запуска PostgreSQL\"\n\
  sleep 50\n\
done\n\
\n\
# Когда PostgreSQL запущен, запускаем приложение\n\
exec \"\$@\"" > /wait-for-postgres.sh && \
    chmod +x /wait-for-postgres.sh



# Копируем и собираем приложение
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ExamAPI/ExamAPI.csproj", "ExamAPI/"]
RUN dotnet restore "./ExamAPI/ExamAPI.csproj"
COPY . .
WORKDIR "/src/ExamAPI"
RUN dotnet build "./ExamAPI.csproj" -c Release -o /app/build

# Публикуем приложение
FROM build AS publish
RUN dotnet publish "./ExamAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Используем aspnet runtime для финального образа
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Добавляем ожидание PostgreSQL перед запуском приложения
CMD ["/wait-for-postgres.sh", "dotnet", "ExamAPI.dll"]
