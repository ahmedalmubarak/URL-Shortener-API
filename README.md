# URL Shortener API

A simple and efficient URL Shortener API that allows users to shorten long URLs into manageable, tiny links. This API is built with `.NET 7`, providing both HTTP and HTTPS endpoints for query and management of shortened URLs.

## Features

- Shorten long URLs to compact links.
- Redirect to the original URL via a shortened link.
- RESTful API design.

## Technologies Used

- **Backend:** .NET 8
- **Database:** SQL Server
- **Hosting:** Kestrel
- **Others:** Dependency Injection, Logging, Exception Handling

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/ahmedalmubarak/URL-Shortener-API.git
   ```

2. Navigate to the project directory:
   ```bash
   cd URL-Shortener-API
   ```

3. Set up the database:
   - Create a SQL Server database for the application.
   - Update the `appsettings.json` file with your database connection string.

4. Build the project:
   ```bash
   dotnet build
   ```

5. Run the project:
   ```bash
   dotnet run
   ```

## API Endpoints

### Shorten a URL

- **Endpoint:** `/api/v1/CreateTinyLink`
- **Method:** `POST`
- **Request Body:**
  ```json
  {
    "OriginalUrl": "https://example.com"
  }
  ```
- **Response:**
  ```json
  {
    "TinyUrl": "https://localhost:7119/abc123"
  }
  ```

### Redirect to Original URL

- **Endpoint:** `/api/v1/Redirect`
- **Method:** `GET`
- **Query Parameter:** `TinyLink`
- **Example:**
  ```
  GET /api/v1/Redirect?TinyLink=https://localhost:7119/abc123
  ```

### Query TinyLink

- **Endpoint:** `/api/v1/QueryTinyLink`
- **Method:** `GET`
- **Query Parameter:** `TinyLink`
- **Example:**
  ```
  GET /api/v1/QueryTinyLink?TinyLink=https://localhost:7119/abc123
  ```

## Usage

### Shortening a URL

Send a `POST` request to the `/api/v1/CreateTinyLink` endpoint with the original URL in the request body. The response will return a shortened URL that can be shared and used for redirection.

### Querying a TinyLink

You can query the details of a shortened URL by sending a `GET` request to the `/api/v1/QueryTinyLink` endpoint with the shortened URL as a query parameter.

### Redirecting to Original URL

When you access the shortened URL, the service will automatically redirect you to the original URL associated with it.

## Contributing

Contributions are welcome! If you'd like to contribute, please fork the repository, make your changes, and submit a pull request.

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add new feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Open a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Acknowledgements

Thanks to all contributors and the open-source community for their support.
```

This file assumes the basic structure of a URL shortener API as outlined in the repository. If any specifics differ from what I've written, feel free to adjust accordingly!
