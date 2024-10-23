# KaihokoApi

KaihokoApi is a C# web API built with .NET 9, utilizing MongoDB as the database and Scalar for testing interfaces.

## Features

- RESTful API endpoints
- MongoDB integration
- Scalar testing interface

## Getting Started

### Prerequisites

- .NET 9 SDK
- MongoDB

### Installation

1. Clone the repository:
    ```sh
    git clone [https://github.com/yourusername/kaihoko_api.git](https://github.com/gustavooliveira2507/KaihokoApi)
    ```
2. Navigate to the project directory:
    ```sh
    cd kaihoko_api/KaihokoApi
    ```
3. Restore the dependencies:
    ```sh
    dotnet restore
    ```

### Configuration

Update the `appsettings.json` file with your MongoDB connection string:
```json
{
  "MongoKaihokoDatabase": {
    "ConnectionString": "",
    "DatabaseName": ""
  },
}
```

### Running the Application

Run the application using the .NET CLI:
```sh
dotnet run --launch-profile https
```

The API will be available at `https://localhost:7161`.

### Testing with Scalar

Access the Scalar testing interface at:
```
https://localhost:7161/scalar/v1
```

## Example Usage

### GET /api/values

Retrieve a list of values:
```sh
curl -X GET "https://localhost:7161/api/values"
```

### POST /api/values

Create a new value:
```sh
curl -X POST "https://localhost:7161/api/values" -H "Content-Type: application/json" -d '{"name":"valueName"}'
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.
