run:
	dotnet run

watch:
	dotnet watch run

build:
	dotnet build

restore:
	dotnet restore

format:
	dotnet format

migration:
	dotnet ef migrations add $(name)

update:
	dotnet ef database update

migrate:
	dotnet ef migrations add $(name)
	dotnet ef database update

remove:
	dotnet ef migrations remove

clean:
	dotnet clean

reset-db:
	dotnet ef database drop --force
	dotnet ef database update