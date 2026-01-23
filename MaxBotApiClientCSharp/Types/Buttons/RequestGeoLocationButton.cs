#region

using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Buttons
{
    /// <summary>
    /// Кнопка для запроса местоположения пользователя
    /// </summary>
    public class RequestGeoLocationButton: Button
    {
        /// <summary>
        /// Кнопка для запроса местоположения пользователя
        /// </summary>
        /// <param name="text">Видимый текст кнопки</param>
        /// <param name="quick">Флаг, указывающий, что местоположение отправляется без запроса подтверждения пользователя. По умолчанию: false</param>
        public RequestGeoLocationButton(string text, bool quick = false): base(ButtonType.RequestGeoLocation, text)
        {
            Quick = quick;
        }

        /// <summary>
        /// Флаг, указывающий, что местоположение отправляется без запроса подтверждения пользователя
        /// </summary>
        public bool Quick { get; }
    }
}