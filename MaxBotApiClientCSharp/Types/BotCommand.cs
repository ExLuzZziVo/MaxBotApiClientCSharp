#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

#endregion

namespace MaxBotApiClientCSharp.Types
{
    /// <summary>
    /// Команда, поддерживаемая ботом
    /// </summary>
    public class BotCommand
    {
        /// <summary>
        /// Команда, поддерживаемая ботом
        /// </summary>
        /// <param name="name">Название команды</param>
        /// <param name="description">Описание команды</param>
        /// <exception cref="ArgumentException">Параметр <paramref name="name"/> обязателен и должен иметь длину не более 64</exception>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="description"/> должен иметь длину не более 128</exception>
        public BotCommand(string name, string description)
        {
            if (name.IsNullOrEmptyOrWhiteSpace() || name.Length > 64)
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"), nameof(name)));
            }

            if (!description.IsNullOrEmptyOrWhiteSpace() && description.Length > 128)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringMaxLengthError"),
                        nameof(description), 128));
            }

            Name = name;
            Description = description;
        }

        /// <summary>
        /// Название команды
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [StringLength(64, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Name { get; }

        /// <summary>
        /// Описание команды
        /// </summary>
        [StringLength(128, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Description { get; }
    }
}