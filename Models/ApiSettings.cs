
namespace HistoryV1Extension.Models
{
    /// <summary>
    /// Represents configuration settings for the API, including base URLs, endpoint URLs, and allowed origins.
    /// This class provides properties to store API-related settings and a method to validate their correctness.
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// Gets or sets the base URL for the application.
        /// </summary>
        /// <value>The base URL as a string.</value>
        public string BaseUrl { get; set; }
        /// <summary>
        /// Gets or sets the URL for the History API v1 get_transaction endpoint.
        /// </summary>
        /// <value>The URL for the v1 get_transaction endpoint as a string.</value>
        public string HistoryApiV1GetTransactionUrl {  get; set; }
        /// <summary>
        /// Gets or sets the URL for the History API v2 get_transaction endpoint.
        /// </summary>
        /// <value>The URL for the v2 get_transaction endpoint as a string.</value>
        public string HistoryApiV2GetTransactionUrl { get; set; }
        /// <summary>
        /// Gets or sets the user agent name used for HTTP requests.
        /// </summary>
        /// <value>The user agent name as a string.</value>
        public string HistoryUserAgentName { get; set; }
        /// <summary>
        /// Gets or sets the array of allowed origins for CORS configuration.
        /// </summary>
        /// <value>An array of allowed origin URLs as strings.</value>
        public string[] AllowedOrigins {  get; set; }

        /// <summary>
        /// Validates all URL properties in the settings to ensure they are correctly formatted.
        /// </summary>
        /// <remarks>
        /// This method checks if <see cref="BaseUrl"/>, <see cref="HistoryApiV1GetTransactionUrl"/>, 
        /// <see cref="HistoryApiV2GetTransactionUrl"/>, and each entry in <see cref="AllowedOrigins"/> 
        /// can be parsed as valid URIs. If any URL is invalid, an exception is thrown.
        /// </remarks>
        /// <exception cref="Exception">
        /// Thrown when any of the URLs (<see cref="BaseUrl"/>, <see cref="HistoryApiV1GetTransactionUrl"/>, 
        /// <see cref="HistoryApiV2GetTransactionUrl"/>, or any entry in <see cref="AllowedOrigins"/>) 
        /// cannot be parsed as a valid URI.
        /// </exception>
        internal void EnsureSuccessValidation()
        {
            var options = new UriCreationOptions() { DangerousDisablePathAndQueryCanonicalization = false };
            try
            {
                ValidateUrl(BaseUrl, in options);
                ValidateUrl(HistoryApiV1GetTransactionUrl, in options);
                ValidateUrl(HistoryApiV2GetTransactionUrl, in options);
                for (var i = 0; i < AllowedOrigins?.Length; i++)
                {
                    ValidateUrl(AllowedOrigins[i], options);
                }
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Validates a single URL string.
        /// </summary>
        /// <param name="url">The URL string to validate and potentially update. Passed by reference.</param>
        /// <param name="options">The <see cref="UriCreationOptions"/> used to configure URI parsing.</param>
        /// <exception cref="Exception">
        /// Thrown when the provided <paramref name="url"/> cannot be parsed as a valid URI.
        /// </exception>
        /// <remarks>
        /// This method uses <see cref="Uri.TryCreate(string, UriCreationOptions, out Uri)"/> to check if the 
        /// <paramref name="url"/> is valid. If invalid, an exception is thrown 
        /// with a descriptive message.
        /// </remarks>
        void ValidateUrl(string url, in UriCreationOptions options)
        {
            if (!Uri.TryCreate(url, options, out _))
            {
                throw new Exception($"{nameof(ValidateUrl)} Error: '{url}' not correct url");
            }
        }
    }
}
