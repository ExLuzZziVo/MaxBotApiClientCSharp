#region

using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Chats.Administrators.SetGroupChatAdministrators
{
    public class SetGroupChatAdministratorsOperation
    {
        /// <summary>
        /// Список пользователей, которые получат права администратора чата
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное количество элементов: 1</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public ChatAdmin[] Admins { get; set; }
    }
}