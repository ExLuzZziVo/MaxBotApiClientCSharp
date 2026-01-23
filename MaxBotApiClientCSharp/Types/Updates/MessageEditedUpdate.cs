#region

using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Updates
{
    /// <summary>
    /// Событие, возникающее при редактировании сообщения
    /// </summary>
    public class MessageEditedUpdate: Update
    {
        public MessageEditedUpdate(): base(UpdateType.MessageEdited) { }

        /// <summary>
        /// Отредактированное сообщение
        /// </summary>
        public Message Message { get; set; }
    }
}