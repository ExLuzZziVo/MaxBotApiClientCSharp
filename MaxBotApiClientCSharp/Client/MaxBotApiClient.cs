#region

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using MaxBotApiClientCSharp.Types.Errors;

#endregion

namespace MaxBotApiClientCSharp.Client
{
    /// <summary>
    /// Клиент бота MAX
    /// </summary>
    public partial class MaxBotApiClient
    {
        protected static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            AllowOutOfOrderMetadataProperties = true
        };

        protected static readonly HttpMethod HttpMethodPatch = new("PATCH");

        protected readonly HttpClient HttpClientInstance;

        /// <summary>
        /// Клиент бота MAX
        /// </summary>
        /// <param name="accessToken">Токен бота</param>
        /// <param name="requestTimeout">Тайм-аут запросов</param>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="accessToken"/> обязателен</exception>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="requestTimeout"/> должен лежать в диапазоне [1,300]. По умолчанию: 15</exception>
        public MaxBotApiClient(string accessToken, int requestTimeout = 15)
        {
            if (accessToken.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            if (!requestTimeout.IsInRange(1, 300))
            {
                throw new ArgumentOutOfRangeException(nameof(requestTimeout));
            }

            HttpClientInstance = new HttpClient
            {
                BaseAddress = new Uri("https://platform-api.max.ru/"),
                DefaultRequestHeaders = { { "Authorization", accessToken } },
                Timeout = TimeSpan.FromSeconds(requestTimeout)
            };
        }

        /// <summary>
        /// Клиент бота MAX
        /// </summary>
        /// <param name="httpClient">Настроенный <see cref="HttpClient"/></param>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="httpClient"/> обязателен</exception>
        public MaxBotApiClient(HttpClient httpClient)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

            HttpClientInstance = httpClient;
        }

        protected virtual async Task<TResult> ExecuteAsync<TResult>(string url, HttpMethod httpMethod,
            object payload = null)
        {
            using var requestMessage = new HttpRequestMessage(httpMethod, url?.TrimStart('/'));

            if (payload != null)
            {
                var dataToSend = JsonSerializer.Serialize(payload, DefaultJsonSerializerOptions);

                requestMessage.Content = new StringContent(dataToSend, Encoding.UTF8, "application/json");
            }

            using var response = await HttpClientInstance.SendAsync(requestMessage);

            return await ProcessResponseAsync<TResult>(response);
        }

        protected virtual async Task<TResult> ProcessResponseAsync<TResult>(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                MaxBotApiClientError error = null;

                if (!responseContent.IsNullOrEmptyOrWhiteSpace())
                {
                    try
                    {
                        error = JsonSerializer.Deserialize<MaxBotApiClientError>(responseContent, DefaultJsonSerializerOptions);
                    }
                    catch
                    {
                        // ignored
                    }
                }

                error ??= new MaxBotApiClientError
                {
                    Code = response.StatusCode.ToString("D"),
                    Message = response.ReasonPhrase
                };

                throw new MaxBotApiClientException(error);
            }

            return JsonSerializer.Deserialize<TResult>(responseContent, DefaultJsonSerializerOptions);
        }
    }
}
