# Call of Duty Easter Egg Quest Guide
This project is a Call of Duty Zombies Easter Egg quest guide website, built with a C# .NET backend and a React frontend. The backend uses Microsoft SQL Server to store game data, including games, maps, main Easter eggs, and side Easter eggs, while the frontend provides an intuitive UI for users to explore quest steps.

## Tech Stack
Backend: C# .NET, Entity Framework Core, Microsoft SQL Server \
Frontend: React, Material UI \
API Design: RESTful endpoints for retrieving and managing Easter egg quests
Features
- Browse Call of Duty Zombies games and maps
- View main and side Easter egg steps for each map
- Organized and structured quest information

This project is a work in progress, and future updates may include user accounts, quest tracking, and community-contributed guides.

## Dev Notes

### C# architecture
- `Controllers`: This folder contains classes that inherit from the Interfaces folder. These classes handle incoming HTTP requests and send responses to the client. In the context of ASP.NET Core, controllers are responsible for managing the interaction between the user interface and the business logic of the application.
- `Data`:  Includes `ApplicationDBContext` which is a bridge between your C# application and the database. This file contains the data access layer of the application, which is responsible for interacting with the database.
- `DTOs`: (Data Transfer Object) is a simple object used to transfer data between layers (e.g., from the frontend to the server or between services) while keeping only the necessary fields and decoupling the API's data structure from the database model.
- `Interfaces`: This folder contains interface definitions for the application. Interfaces define contracts that must be implemented by any class that implements them.
- `Mappers`: This folder contains classes that are responsible for mapping between different data models, such as mapping between the database entity models and the DTO (Data Transfer Object) models used for API responses.
- `Models`: This folder contains the entity models that represent the data stored in the database. These models correspond to the tables in the database and define the structure of the data.
- `Repository`: This folder contains classes that encapsulate the data access logic for the application. Repositories are responsible for retrieving and manipulating data in the database, and they provide a layer of abstraction between the business logic and the data storage.
- `Migrations`: This folder contains the database migration scripts that are used to update the database schema as the application evolves.
- `Program.cs`: This file is the entry point of the application and contains the code that sets up the ASP.NET Core pipeline and starts the application.


### dotnet commands

- `dotnet ef migrations add init`
- `dotnet ef database update`
- `dotnet watch run`
- `dotnet ef migrations remove`
- `dotnet build`

### react commands

- `npm install`
- `npm run dev`

### api url

http://localhost:5170/swagger/index.html

### games landing page

http://localhost:5173/games
