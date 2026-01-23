#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Buttons
{
    /// <summary>
    /// Кнопка
    /// </summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(CallbackButton), "callback")]
    [JsonDerivedType(typeof(LinkButton), "link")]
    [JsonDerivedType(typeof(MessageButton), "message")]
    [JsonDerivedType(typeof(OpenAppButton), "open_app")]
    [JsonDerivedType(typeof(RequestContactButton), "request_contact")]
    [JsonDerivedType(typeof(RequestGeoLocationButton),
        "request_geo_location")]
    public abstract class Button
    {
        /// <summary>
        /// Кнопка
        /// </summary>
        /// <param name="type">Тип кнопки</param>
        /// <param name="text">Видимый текст кнопки</param>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="text"/> обязателен и должен иметь длину [1-128]</exception>
        [JsonConstructor]
        protected Button(ButtonType type, string text)
        {
            if (text.IsNullOrEmptyOrWhiteSpace() || !text.Length.IsInRange(1, 128))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"), nameof(text)));
            }

            Type = type;
            Text = text;
        }

        /// <summary>
        /// Тип кнопки
        /// </summary>
        [JsonIgnore]
        public ButtonType Type { get; }

        /// <summary>
        /// Видимый текст кнопки
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно иметь длину: [1-128]</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [StringLength(128, MinimumLength = 1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringRangeLengthError")]
        public string Text { get; }
    }
}
