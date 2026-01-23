#region

using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Operations;
using MaxBotApiClientCSharp.Types.Operations.Subscriptions.GetAllSubscriptions;
using MaxBotApiClientCSharp.Types.Operations.Subscriptions.GetSubscriptionsUpdates;
using MaxBotApiClientCSharp.Types.Operations.Subscriptions.SubscribeToUpdates;

#endregion

namespace MaxBotApiClientCSharp.Client
{
    public partial class MaxBotApiClient
    {
        /// <summary>
        /// Запрашивает список текущих подписок
        /// </summary>
        /// <returns>Список текущих подписок</returns>
        public virtual async Task<GetAllSubscriptionsResult> GetAllSubscriptionsAsync()
        {
            return await ExecuteAsync<GetAllSubscriptionsResult>("/subscriptions", HttpMethod.Get);
        }

        /// <summary>
        /// Подписывает бота на получение обновлений через WebHook на указанный <paramref name="url"/>
        /// </summary>
        /// <param name="url">URL HTTP(S)-эндпойнта бота</param>
        /// <param name="secret">Секрет, который должен быть отправлен в заголовке "X-Max-Bot-Api-Secret" в каждом запросе Webhook</param>
        /// <param name="updateTypes">Обновления, которые бот хочет получать</param>
        /// <returns>Результат выполнения операции</returns>
        /// <exception cref="ArgumentException">
        /// <para>
        /// Параметр <paramref name="url"/> обязателен и должен соответствовать регулярному выражению <see cref="RegexExtensions.UrlPattern"/>
        /// </para>
        /// <para>
        /// Параметр <paramref name="updateTypes"/> обязателен и должен содержать хотя бы один элемент
        /// </para>
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="secret"/> должен иметь длину [5-256]</exception>
        public virtual async Task<CommonOperationResult> SubscribeToUpdatesAsync(string url, string secret,
            params UpdateType[] updateTypes)
        {
            if (url.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(url, RegexExtensions.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"), nameof(url)),
                    nameof(url));
            }

            if (secret != null && !secret.Length.IsInRange(5, 256))
            {
                throw new ArgumentOutOfRangeException(nameof(secret));
            }

            if (updateTypes == null || updateTypes.Length == 0)
            {
                throw new ArgumentException(string.Format(
                    ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"), nameof(updateTypes), 1));
            }

            return await ExecuteAsync<CommonOperationResult>("/subscriptions", HttpMethod.Post,
                new SubscribeToUpdatesOperation
                {
                    Url = url,
                    UpdateTypes = updateTypes,
                    Secret = secret
                });
        }

        /// <summary>
        /// Отписывает бота от получения обновлений через Webhook
        /// </summary>
        /// <param name="url">URL, который нужно удалить из подписок на WebHook</param>
        /// <returns>Результат выполнения операции</returns>
        /// <exception cref="ArgumentException">Параметр <paramref name="url"/> обязателен и должен соответствовать регулярному выражению <see cref="RegexExtensions.UrlPattern"/></exception>
        public virtual async Task<CommonOperationResult> UnsubscribeFromUpdatesAsync(string url)
        {
            if (url.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(url, RegexExtensions.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"), nameof(url)),
                    nameof(url));
            }

            return await ExecuteAsync<CommonOperationResult>($"/subscriptions?url={url}", HttpMethod.Delete);
        }

        /// <summary>
        /// Получает обновления вручную
        /// </summary>
        /// <param name="limit">Максимальное количество обновлений для получения. По умолчанию: 100</param>
        /// <param name="timeout">Тайм-аут в секундах для долгого опроса. По умолчанию: 30</param>
        /// <param name="marker">Указатель на следующую страницу данных. Для первой страницы: null</param>
        /// <param name="updateTypes">Типы обновлений</param>
        /// <returns>Обновления</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>
        /// Параметр <paramref name="limit"/> должен лежать в диапазоне [1-1000]
        /// </para>
        /// <para>
        /// Параметр <paramref name="timeout"/> должен лежать в диапазоне [0-90]
        /// </para>
        /// </exception>
        /// <exception cref="ArgumentException">Параметр <paramref name="updateTypes"/> обязателен и должен содержать хотя бы один элемент</exception>
        public virtual async Task<GetSubscriptionsUpdatesResult> GetSubscriptionsUpdatesAsync(int limit = 100,
            int timeout = 30, long? marker = null, params UpdateType[] updateTypes)
        {
            if (!limit.IsInRange(1, 1000))
            {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }

            if (!timeout.IsInRange(0, 90))
            {
                throw new ArgumentOutOfRangeException(nameof(timeout));
            }

            if (updateTypes == null || updateTypes.Length == 0)
            {
                throw new ArgumentException(string.Format(
                    ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"), nameof(updateTypes), 1));
            }

            return await ExecuteAsync<GetSubscriptionsUpdatesResult>("/updates", HttpMethod.Get,
                new GetSubscriptionsUpdatesOperation
                {
                    Limit = limit,
                    Timeout = timeout,
                    Marker = marker,
                    Types = updateTypes
                });
        }
    }
}