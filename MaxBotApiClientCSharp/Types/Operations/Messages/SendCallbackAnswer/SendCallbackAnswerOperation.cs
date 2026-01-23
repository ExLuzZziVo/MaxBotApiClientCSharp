#region

using CoreLib.CORE.Helpers.ValidationHelpers.Attributes;
using CoreLib.CORE.Resources;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Messages.SendCallbackAnswer
{
    public class SendCallbackAnswerOperation
    {
        /// <summary>
        /// Содержимое текущего сообщения
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="Notification"/> имеет значение null</item>
        /// </list>
        [RequiredIf(nameof(Notification), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        public NewMessageBody Message { get; set; }

        /// <summary>
        /// Текст одноразового уведомления пользователю
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если <see cref="Message"/> имеет значение null</item>
        /// </list>
        [RequiredIf(nameof(Message), null, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "RequiredError")]
        public string Notification { get; set; }
    }
}