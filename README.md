# History v1 Extension

**History v1 Extension** is a C# cross-platform Web API project designed to extend and correct the `/v1/history` endpoint for blockchain APIs such as [Leap](https://github.com/AntelopeIO/leap) and [Hyperion API](https://github.com/eosrio/hyperion-history-api). The `/v1/history/` path is considered deprecated in Hyperion API and often returns incomplete data. However, local blockchain explorers like [local.bloks.io](https://local.bloks.io) and [eosauthority.com](https://eosauthority.com) still rely on this endpoint. This project acts as a middleware, fetching data from Hyperion API and formatting it into a proper JSON response for the `/v1/history/get_transaction` endpoint.

## Features

- Corrects and extends the `/v1/history/get_transaction` endpoint for compatibility with local blockchain explorers.
- Integrates with Hyperion API using configurable endpoints in `appsettings.json`.
- Supports reverse proxy setups (e.g., Apache2, Nginx) to route requests appropriately.
- Includes CORS support for specified blockchain explorer origins.

## Project Structure

- **Controllers**: Handles requests to `/v1/history/get_transaction`.
- **Models**: Defines the data structures for API responses.
- **appsettings.json**: Configuration file for API endpoints, user agent, and allowed origins.

## Configuration

The project is configured via the `appsettings.json` file. Below is an example configuration:

```json
{
  "ApiSettings": {
    "BaseUrl": "http://192.168.0.101:5194",
    "HistoryApiV1GetTransactionUrl": "https://api-local.saltant.io/v1/history/get_transaction",
    "HistoryApiV2GetTransactionUrl": "https://api-local.saltant.io/v2/history/get_transaction",
    "HistoryUserAgentName": "History API Extension",
    "AllowedOrigins": [
      "https://local.bloks.io",
      "https://eosauthority.com"
    ]
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
### Configuration Fields

- **BaseUrl**: The address where this API will be hosted (e.g., `http://192.168.0.101:5194`).
- **HistoryApiV1GetTransactionUrl**: The Hyperion API `/v1/history/get_transaction` endpoint URL.
- **HistoryApiV2GetTransactionUrl**: The Hyperion API `/v2/history/get_transaction` endpoint URL.
- **HistoryUserAgentName**: Identifies requests from this extension (default: `"History API Extension"`). Used by the reverse proxy to differentiate internal and external requests—typically no need to change this.
- **AllowedOrigins**: Array of URLs for blockchain explorers allowed to access the API via CORS (e.g., `["https://local.bloks.io", "https://eosauthority.com"]`). Update if using different explorers.

> **Note**: Replace the URLs in `ApiSettings` with your own Hyperion API endpoints and the address where this extension will run.

## Reverse Proxy Setup

To integrate this extension with your Hyperion API, configure a reverse proxy (e.g., Apache2 or Nginx) to route requests as follows:
1. External requests to `/v1/history/get_transaction` (e.g., from blockchain explorers) should go to this API.
2. Internal requests from this API (identified by `HistoryUserAgentName`) and all other `/v1/history/` requests should go directly to Hyperion API.

### Example Apache2 Reverse Proxy Configuration

```apache
# Rule for /v1/history/get_transaction from external clients
RewriteCond %{HTTP_USER_AGENT} !^History\ API\ Extension$ [NC]
RewriteCond %{REQUEST_METHOD} ^POST$ [NC]
RewriteCond %{REQUEST_URI} ^/v1/history/get_transaction$ [NC]
RewriteRule ^/v1/history/get_transaction$ http://192.168.0.101:5194/v1/history/get_transaction [P,L]

# Default rule for all other /v1/history/ requests
RewriteCond %{REQUEST_URI} ^/v1/history/
RewriteRule ^/v1/history/(.*)$ http://192.168.0.110:7000/v1/history/$1 [P,L]
```
- **Explanation**:
  - The first rule routes `POST` requests to `/v1/history/get_transaction` from external clients (not using the `History API Extension` user agent) to this API (`http://192.168.0.101:5194`).
  - The second rule forwards all other `/v1/history/` requests, including internal ones from this API, to the Hyperion API (`http://192.168.0.110:7000`).

> **Note**: Update the IP addresses and ports to match your setup. This example assumes the extension runs on `http://192.168.0.101:5194` and Hyperion API on `http://192.168.0.110:7000`.

## How It Works

- **External Requests**: A blockchain explorer sends a `POST` request to `/v1/history/get_transaction`. The reverse proxy routes it to this API, which fetches data from Hyperion’s `/v1/history/get_transaction` and `/v2/history/get_transaction` endpoints, processes it, and returns a corrected JSON response.
- **Internal Requests**: When this API makes requests to Hyperion (using `History API Extension` as the user agent), the reverse proxy routes them directly to Hyperion API, avoiding loops.
- **Other Requests**: All other `/v1/history/` endpoints (e.g., `/v1/history/get_actions`) are proxied directly to Hyperion API, as this project only handles `/v1/history/get_transaction`.

## Setup Instructions

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/Saltant/HistoryV1Extension.git
   ```
2. **Configure `appsettings.json`**:
   - Update `BaseUrl` with the address where this API will run.
   - Set `HistoryApiV1GetTransactionUrl` and `HistoryApiV2GetTransactionUrl` to your Hyperion API endpoints.
   - Adjust `AllowedOrigins` if needed.

3. **Build and Run**:
   - Use Visual Studio or the .NET CLI:
     ```bash
     dotnet run --project HistoryV1Extension
     ```

4. **Configure Reverse Proxy**:
   - Set up your web server (e.g., Apache2) with the rules provided above.

5. **Test the Endpoint**:
   - Use `curl` or Postman to verify the `/v1/history/get_transaction` endpoint works through your reverse proxy.

## License

This project is licensed under the GPLv3 License.
