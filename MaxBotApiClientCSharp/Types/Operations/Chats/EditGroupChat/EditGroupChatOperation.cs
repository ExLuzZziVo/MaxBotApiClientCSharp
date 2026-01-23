#region

using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Attachments.Request.Payloads;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Chats.EditGroupChat
{
    public class EditGroupChatOperation
    {
        /// <summary>
        /// Изображение чата
        /// </summary>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public ImageAttachmentRequestPayload Icon { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        /// <list type="bullet">
        /// <item>Должно иметь длину: [1-200]</item>
        /// </list>
        [StringLength(200, MinimumLength = 1, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringRangeLengthError")]
        public string Title { get; set; }

        /// <summary>
        /// ID сообщения для закрепления в чате
        /// </summary>
        public string Pin { get; set; }

        /// <summary>
        /// Флаг, указывающий будут ли участники чата уведомлены об изменении
        /// </summary>
        /// <remarks>
        /// Значение по умолчанию: true
        /// </remarks>
        public bool Notify { get; set; } = true;
    }
}