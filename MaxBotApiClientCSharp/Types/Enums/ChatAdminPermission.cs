#region

using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace MaxBotApiClientCSharp.Types.Enums
{
    /// <summary>
    /// Права пользователя
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum ChatAdminPermission: byte
    {
        /// <summary>
        /// Чтение всех сообщений
        /// </summary>
        [JsonStringEnumMemberName("read_all_messages")]
        ReadAllMessages,

        /// <summary>
        /// Добавление/удаление участников
        /// </summary>
        [JsonStringEnumMemberName("add_remove_members")]
        AddRemoveMembers,

        /// <summary>
        /// Добавление администраторов
        /// </summary>
        [JsonStringEnumMemberName("add_admins")]
        AddAdmins,

        /// <summary>
        /// Изменение информации о чате
        /// </summary>
        [JsonStringEnumMemberName("change_chat_info")]
        ChangeChatInfo,

        /// <summary>
        /// Закрепление сообщения
        /// </summary>
        [JsonStringEnumMemberName("pin_message")]
        PinMessage,

        /// <summary>
        /// Писать сообщения
        /// </summary>
        [JsonStringEnumMemberName("write")] Write,

        /// <summary>
        /// Совершать звонки
        /// </summary>
        [JsonStringEnumMemberName("can_call")] CanCall,

        /// <summary>
        /// Изменение ссылок на чат
        /// </summary>
        [JsonStringEnumMemberName("edit_link")]
        EditLink,

        /// <summary>
        /// Публиковать, редактировать и удалять сообщения
        /// </summary>
        [JsonStringEnumMemberName("post_edit_delete_message")]
        PostEditDeleteMessage,

        /// <summary>
        /// Редактировать сообщения
        /// </summary>
        [JsonStringEnumMemberName("edit_message")]
        EditMessage,

        /// <summary>
        /// Удалять сообщения
        /// </summary>
        [JsonStringEnumMemberName("delete_message")]
        DeleteMessage
    }
}