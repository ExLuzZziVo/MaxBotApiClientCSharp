#region

using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;

#endregion

namespace MaxBotApiClientCSharp.Types.Enums
{
    /// <summary>
    /// Тип обновления
    /// </summary>
    [JsonConverter(typeof(JsonCamelCaseStringEnumConverter))]
    public enum UpdateType: byte
    {
        /// <summary>
        /// Событие, возникающее, когда бот присоединился к чату
        /// </summary>
        [JsonStringEnumMemberName("bot_added")]
        BotAdded,

        /// <summary>
        /// Событие, возникающее, когда бот был удален из чата
        /// </summary>
        [JsonStringEnumMemberName("bot_removed")]
        BotRemoved,

        /// <summary>
        /// Событие, возникающее, когда пользователь нажал кнопку 'Start'
        /// </summary>
        [JsonStringEnumMemberName("bot_started")]
        BotStarted,

        /// <summary>
        /// Событие, возникающее, когда пользователь остановил чат
        /// </summary>
        [JsonStringEnumMemberName("bot_stopped")]
        BotStopped,

        /// <summary>
        /// Событие, возникающее, когда было изменено название чата
        /// </summary>
        [JsonStringEnumMemberName("chat_title_changed")]
        ChatTitleChanged,

        /// <summary>
        /// Событие, возникающее, когда диалог был очищен
        /// </summary>
        [JsonStringEnumMemberName("dialog_cleared")]
        DialogCleared,

        /// <summary>
        /// Событие, возникающее, когда пользователь отключил уведомления
        /// </summary>
        [JsonStringEnumMemberName("dialog_muted")]
        DialogMuted,

        /// <summary>
        /// Событие, возникающее, когда пользователь удалил чат
        /// </summary>
        [JsonStringEnumMemberName("dialog_removed")]
        DialogRemoved,

        /// <summary>
        /// Событие, возникающее, когда пользователь включил уведомления
        /// </summary>
        [JsonStringEnumMemberName("dialog_unmuted")]
        DialogUnmuted,

        /// <summary>
        /// Событие, возникающее, когда пользователь нажал на кнопку
        /// </summary>
        [JsonStringEnumMemberName("message_callback")]
        MessageCallback,

        /// <summary>
        /// Событие, возникающее при отправке нового сообщения
        /// </summary>
        [JsonStringEnumMemberName("message_created")]
        MessageCreated,

        /// <summary>
        /// Событие, возникающее при редактировании сообщения
        /// </summary>
        [JsonStringEnumMemberName("message_edited")]
        MessageEdited,

        /// <summary>
        /// Событие, возникающее при удалении сообщения
        /// </summary>
        [JsonStringEnumMemberName("message_removed")]
        MessageRemoved,

        /// <summary>
        /// Событие, возникающее, когда пользователь был добавлен в чат
        /// </summary>
        [JsonStringEnumMemberName("user_added")]
        UserAdded,

        /// <summary>
        /// Событие, возникающее, когда пользователь был удален из чата
        /// </summary>
        [JsonStringEnumMemberName("user_removed")]
        UserRemoved
    }
}