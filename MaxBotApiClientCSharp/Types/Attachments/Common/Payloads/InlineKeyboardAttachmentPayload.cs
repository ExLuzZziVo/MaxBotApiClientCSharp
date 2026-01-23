#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Helpers;
using MaxBotApiClientCSharp.Types.Buttons;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Common.Payloads
{
    public class InlineKeyboardAttachmentPayload
    {
        /// <summary>
        /// Двумерный массив кнопок
        /// </summary>
        [TwoDimensionalArrayConverter<Button>]
        public Button[,] Buttons { get; set; }
    }
}
