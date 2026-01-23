#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Chats.Members.GetGroupChatMembers
{
    public class GetGroupChatMembersOperation
    {
        /// <summary>
        /// Список ID пользователей, чье членство нужно получить
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="Count"/> имеет значение null</item>
        /// <item>Минимальное количество элементов: 1</item>
        /// </list>
        /// <remarks>
        /// Когда этот параметр передан, параметры count и marker игнорируются
        /// </remarks>
        [JsonPropertyName("user_ids")]
        [RequiredIf(nameof(Count), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public long[] UserIds { get; set; }

        /// <summary>
        /// Количество запрашиваемых участников
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="UserIds"/> имеет значение null</item>
        /// <item>Должно лежать в диапазоне: 1-100</item>
        /// </list>
        /// <remarks>
        /// Значение по умолчанию: 20
        /// </remarks>
        [RequiredIf(nameof(UserIds), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [Range(1, 100, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int? Count { get; set; } = 20;

        /// <summary>
        /// Указатель на следующую страницу данных
        /// </summary>
        /// <remarks>
        /// Для первой страницы: null
        /// </remarks>
        public long? Marker { get; set; }
    }
}