# Inventory Manager API

## Project Overview

This is an inventory management API built using C# .NET Minimal API. The API manages products, categories, suppliers, and inventory transactions. It supports basic CRUD operations for each entity and uses PostgreSQL as the database.

Generate an image with: dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer

or

dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer -p:ContainerImageName=imgnamehere

and

docker tag todo-api:latest mikelautensack/dotnet-controllers-todo-api:latest

and

docker push mikelautensack/imgname:latest
