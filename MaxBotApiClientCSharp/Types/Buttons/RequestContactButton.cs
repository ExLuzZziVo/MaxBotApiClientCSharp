#region

using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Buttons
{
    /// <summary>
    /// Кнопка для запроса контактных данных
    /// </summary>
    public class RequestContactButton: Button
    {
        /// <summary>
        /// Кнопка для запроса контактных данных
        /// </summary>
        /// <param name="text">Видимый текст кнопки</param>
        public RequestContactButton(string text): base(ButtonType.RequestContact, text) { }
    }
}