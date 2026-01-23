#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Resources;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Chats.Members.AddGroupChatMembers
{
    public class AddGroupChatMembersOperation
    {
        /// <summary>
        /// Список ID пользователей, которых нужно добавить в чат
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное количество элементов: 1</item>
        /// </list>
        [JsonPropertyName("user_ids")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public long[] UserIds { get; set; }
    }
}