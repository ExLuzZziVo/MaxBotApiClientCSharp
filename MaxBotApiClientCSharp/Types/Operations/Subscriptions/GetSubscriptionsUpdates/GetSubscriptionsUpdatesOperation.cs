#region

using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Subscriptions.GetSubscriptionsUpdates
{
    public class GetSubscriptionsUpdatesOperation
    {
        /// <summary>
        /// Максимальное количество обновлений для получения
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 1-1000</item>
        /// </list>
        /// <remarks>
        /// Значение по умолчанию: 100
        /// </remarks>
        [Range(1, 1000, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int Limit { get; set; } = 100;

        /// <summary>
        /// Тайм-аут в секундах для долгого опроса
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 1-90</item>
        /// </list>
        /// <remarks>
        /// Значение по умолчанию: 30
        /// </remarks>
        [Range(0, 90, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int Timeout { get; set; } = 30;

        /// <summary>
        /// Указатель на следующую страницу данных
        /// </summary>
        /// <remarks>
        /// Для первой страницы: null
        /// </remarks>
        public long? Marker { get; set; }

        /// <summary>
        /// Список типов обновлений, которые бот хочет получить
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное количество элементов: 1</item>
        /// </list>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [MinLength(1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "CollectionMinLengthError")]
        public UpdateType[] Types { get; set; }
    }
}