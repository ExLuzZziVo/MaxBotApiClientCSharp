#region

using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Chats.GetAllGroupChats
{
    public class GetAllGroupChatsOperation
    {
        /// <summary>
        /// Количество запрашиваемых чатов
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

        /// <summary>
        /// Указатель на следующую страницу данных
        /// </summary>
        /// <remarks>
        /// Для первой страницы: null
        /// </remarks>
        public long? Marker { get; set; }
    }
}