#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Subscriptions.SubscribeToUpdates
{
    public class SubscribeToUpdatesOperation
    {
        /// <summary>
        /// URL HTTP(S)-эндпойнта бота
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению: <see cref="RegexExtensions.UrlPattern"/></item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [RegularExpression(RegexExtensions.UrlPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Url { get; set; }

        /// <summary>
        /// Список типов обновлений, которые бот хочет получать
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное количество элементов: 1</item>
        /// </list>
        [JsonPropertyName("update_types")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public UpdateType[] UpdateTypes { get; set; }

        /// <summary>
        /// Секрет, который должен быть отправлен в заголовке "X-Max-Bot-Api-Secret" в каждом запросе Webhook
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно иметь длину: [5-256]</item>
        /// <item>Должно соответствовать регулярному выражению: ^[a-zA-Z0-9_-]{5,256}$</item>
        /// </list>
        /// <remarks>
        /// Заголовок рекомендован, чтобы запрос поступал из установленного веб-узла
        /// </remarks>
        [StringLength(256, MinimumLength = 5, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringLengthError")]
        [RegularExpression(@"^[a-zA-Z0-9_-]{5,256}$", ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string Secret { get; set; }
    }
}