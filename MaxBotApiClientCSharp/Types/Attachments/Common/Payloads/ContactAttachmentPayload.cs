#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common.Payloads
{
    public class ContactAttachmentPayload
    {
        /// <summary>
        /// Информация о пользователе в формате VCF
        /// </summary>
        [JsonPropertyName("vcf_info")]
        public string VcfInfo { get; set; }

        /// <summary>
        /// Информация о пользователе
        /// </summary>
        [JsonPropertyName("max_info")]
        public User MaxInfo { get; set; }
    }
}