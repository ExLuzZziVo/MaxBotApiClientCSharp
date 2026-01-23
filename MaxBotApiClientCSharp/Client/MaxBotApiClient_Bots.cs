#region

using System.Net.Http;
using System.Threading.Tasks;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Client
{
    public partial class MaxBotApiClient
    {
        /// <summary>
        /// Запрос информации о текущем боте
        /// </summary>
        /// <returns>
        /// Информация о текущем боте, который идентифицируется с помощью токена доступа
        /// </returns>
        public virtual async Task<BotInfo> GetBotInfoAsync()
        {
            return await ExecuteAsync<BotInfo>("/me", HttpMethod.Get);
        }
    }
}