# AEChallenge
## This application describes a simple way to manage ships based on the requirements from https://github.com/angloeastern/backend-coding-task.

## Technical description:
- Programming language: Aspnet Core Web API
## Application architecture:
- **AEPortal**: Includes controllers and a Docker file.
- **AEPortal.Business**: Handles logic, implements mapping, UnitOfWork, repository configuration, response models, middleware, etc.
- **AEPortal.Business**: Configures packages for the application, logging, constants, enums, global exception handling, base response configuration, and base search model.
- **AEPortal.Data**: Configures entities and the project's context. Data migration is performed.

**Note**:
The distance between the ship and each port is calculated using a CalculateDistance function , which takes the geolocation (longitude and latitude) of both points as input and returns the distance between them. Once the closest port is found, the estimated time to that port is calculated by dividing the distance by the velocity of the ship. Finally, a ShipClosestPortResponse object is created containing the details of the closest port and the estimated arrival time and returned. Here are the calculated distances (in kilometers) between each ship and each port:
Example data:

![image](https://github.com/ThanhDeveloper/AEChallenge/assets/48196420/f33184a6-fbe7-4c20-9c21-35ed81dffcc7)

Based on sample data, when you run the api the data will return the nearest port which is port 5

- Ship 1:
  - Port 1: 3243.98 km
  - Port 2: 10018.44 km
  - Port 3: 17817.10 km
  - Port 4: 13035.95 km
  - Port 5: 3027.59 km

- Ship 2:
  - Port 1: 3330.60 km
  - Port 2: 10524.85 km
  - Port 3: 17462.86 km
  - Port 4: 12681.71 km
  - Port 5: 2448.62 km

As you can see, Port 5 is indeed the closest port to both Ship 1 and Ship 2.




## API Endpoints
The solution includes the following API endpoints. I have attached the model description of the response in each swagger api:

- `GET /api/ships`: Retrieve a list of all ships
- `GET /api/ships/{id}/closest-port`: Get closest port by providing the ship's unique identifier
- `POST /api/ships`: Create a ship by providing ship details
- `PUT /api/ships/{id}/velocity`: Update the velocity of a ship by providing the ship's unique identifier.

## Demo
- Swagger
![image](https://github.com/ThanhDeveloper/AEChallenge/assets/48196420/08bb3dca-1c2e-4788-9eb2-d42b30be0092)

- Response description
![image](https://github.com/ThanhDeveloper/AEChallenge/assets/48196420/58c8edd9-b6f3-4257-80ac-308257cf2084)

## Docker support
