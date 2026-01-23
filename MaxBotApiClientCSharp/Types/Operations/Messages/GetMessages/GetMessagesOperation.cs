#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.Converters;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Messages.GetMessages
{
    public class GetMessagesOperation
    {
        /// <summary>
        /// Время начала для запрашиваемых сообщений
        /// </summary>
        [UnixTimestampConverter]
        public DateTime? From { get; set; }

        /// <summary>
        /// Время окончания для запрашиваемых сообщений
        /// </summary>
        [UnixTimestampConverter]
        [CompareTo(nameof(From), ComparisonType.GreaterOrEqual, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CompareToGreaterThanOrEqualError")]
        public DateTime? To { get; set; }

        /// <summary>
        /// Максимальное количество сообщений в ответе
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 1-100</item>
        /// </list>
        /// <remarks>
        /// Значение по умолчанию: 50
        /// </remarks>
        [Range(1, 100, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int Count { get; set; } = 50;
    }
}