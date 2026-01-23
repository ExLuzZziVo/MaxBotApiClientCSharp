#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common.Payloads
{
    public abstract class AttachmentPayload
    {
        /// <summary>
        /// URL вложения
        /// </summary>
        public string Url { get; set; }
    }
}
