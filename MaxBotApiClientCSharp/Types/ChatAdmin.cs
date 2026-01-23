#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Пользователь, который получит права администратора чата
    /// </summary>
    public class ChatAdmin
    {
        /// <summary>
        /// Пользователь, который получит права администратора чата
        /// </summary>
        /// <param name="userId">ID пользователя-участника чата, который назначается администратором</param>
        /// <param name="permissions">Перечень прав доступа пользователя</param>
        /// <exception cref="ArgumentException">Параметр <paramref name="permissions"/> обязателен и должен содержать хотя бы один элемент</exception>
        public ChatAdmin(long userId, params ChatAdminPermission[] permissions)
        {
            if (permissions == null || permissions.Length == 0)
            {
                throw new ArgumentException(string.Format(
                    ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"), nameof(permissions), 1));
            }

            UserId = userId;
            Permissions = permissions;
        }

        /// <summary>
        /// Пользователь, который получит права администратора чата
        /// </summary>
        /// <param name="userId">ID пользователя-участника чата, который назначается администратором</param>
        /// <param name="alias">Заголовок, который будет показан на клиенте</param>
        /// <param name="permissions">Перечень прав доступа пользователя</param>
        /// <exception cref="ArgumentException">Параметр <paramref name="permissions"/> обязателен и должен содержать хотя бы один элемент</exception>
        public ChatAdmin(long userId, string alias, params ChatAdminPermission[] permissions)
        {
            if (permissions == null || permissions.Length == 0)
            {
                throw new ArgumentException(string.Format(
                    ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"), nameof(permissions), 1));
            }

            UserId = userId;
            Alias = alias;
            Permissions = permissions;
        }

        /// <summary>
        /// ID пользователя-участника чата, который назначается администратором
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; }

        /// <summary>
        /// Перечень прав доступа пользователя
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное количество элементов: 1</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public ChatAdminPermission[] Permissions { get; }

        /// <summary>
        /// Заголовок, который будет показан на клиенте
        /// </summary>
        /// <remarks>
        /// Если пользователь администратор или владелец и ему не установлено это название, то поле не передаётся, клиенты на своей стороне подменят на "владелец" или "админ"
        /// </remarks>
        public string Alias { get; }
    }
}