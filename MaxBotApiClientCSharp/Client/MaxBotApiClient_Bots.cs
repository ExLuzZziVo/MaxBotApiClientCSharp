#region

using System;
using System.Net.Http;
using System.Threading.Tasks;
using MaxBotApiClientCSharp.Types.Operations.Bots.EditBotInfo;
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

        // ToDo нет информации о методе в официальной документации
        /// <summary>
        /// Редактирует информацию о боте
        /// </summary>
        /// <param name="botInfo">Параметры редактирования информации о боте</param>
        /// <returns>Отредактированная информация о боте</returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="botInfo"/> обязателен</exception>
        public virtual async Task<BotInfo> EditBotInfoAsync(EditBotInfoOperation botInfo)
        {
            if (botInfo == null)
            {
                throw new ArgumentNullException(nameof(botInfo));
            }

            return await ExecuteAsync<BotInfo>("/me", HttpMethodPatch, botInfo);
        }
    }
}