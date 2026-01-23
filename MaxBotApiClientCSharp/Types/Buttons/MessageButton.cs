#region

using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Buttons
{
    /// <summary>
    /// Кнопка для отправки сообщения
    /// </summary>
    public class MessageButton: Button
    {
        /// <summary>
        /// Кнопка для отправки сообщения
        /// </summary>
        /// <param name="text">Текст кнопки, который будет отправлен в чат от лица пользователя</param>
        public MessageButton(string text): base(ButtonType.Message, text) { }
    }
}