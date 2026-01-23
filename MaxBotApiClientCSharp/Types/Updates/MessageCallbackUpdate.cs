#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Updates
{
    /// <summary>
    /// Событие, возникающее, когда пользователь нажал на кнопку
    /// </summary>
    public class MessageCallbackUpdate: Update
    {
        public MessageCallbackUpdate(): base(UpdateType.MessageCallback) { }

        /// <summary>
        /// Результат нажатия кнопки бота пользователем
        /// </summary>
        public Callback Callback { get; set; }

        /// <summary>
        /// Изначальное сообщение, содержащее встроенную клавиатуру
        /// </summary>
        /// <remarks>
        /// Может быть null, если оно было удалено к моменту, когда бот получил это обновление
        /// </remarks>
        public Message Message { get; set; }

        /// <summary>
        /// Текущий язык пользователя в формате IETF BCP 47
        /// </summary>
        [JsonPropertyName("user_locale")]
        public string UserLocale { get; set; }
    }
}