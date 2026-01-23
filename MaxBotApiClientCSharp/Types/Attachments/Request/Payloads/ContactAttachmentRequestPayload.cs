#region

using System.Text.Json.Serialization;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Request.Payloads
{
    // ToDo правила валидации. В документации про обязательность полей ничего нет
    /// <summary>
    /// Данные прикрепляемого контакта
    /// </summary>
    public class ContactAttachmentRequestPayload
    {
        /// <summary>
        /// Имя контакта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID контакта, если он зарегистрирован в MAX
        /// </summary>
        [JsonPropertyName("contact_id")]
        public long? ContactId { get; set; }

        /// <summary>
        /// Полная информация о контакте в формате VCF
        /// </summary>
        [JsonPropertyName("vcf_info")]
        public string VcfInfo { get; set; }

        /// <summary>
        /// Телефон контакта в формате VCF
        /// </summary>
        [JsonPropertyName("vcf_phone")]
        public string VcfPhone { get; set; }
    }
}