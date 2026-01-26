#region

using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Attachments.Request.Payloads;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Bots.EditBotInfo
{
    /// <summary>
    /// Параметры редактирования информации о боте
    /// </summary>
    /// <remarks>
    /// Если значение какого-либо поля null, то оно не будет изменено
    /// </remarks>
    public class EditBotInfoOperation
    {
        /// <summary>
        /// Название бота
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 1024</item>
        /// </list>
        [StringLength(1024, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Name { get; set; }

        /// <summary>
        /// Описание бота
        /// </summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 200</item>
        /// </list>
        [StringLength(200, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Description { get; set; }

        /// <summary>
        /// Команды, поддерживаемые ботом
        /// </summary>
        /// <remarks>
        /// Чтобы очистить список команд, необходимо передать пустой массив
        /// </remarks>
        [ComplexObjectCollectionValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectCollectionValidationError")]
        public BotCommand[] Commands { get; set; }

        /// <summary>
        /// Аватар бота
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public ImageAttachmentRequestPayload Photo { get; set; }
    }
}