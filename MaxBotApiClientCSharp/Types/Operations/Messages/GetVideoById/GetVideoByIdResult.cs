#region

using MaxBotApiClientCSharp.Types.Attachments.Common.Payloads;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Messages.GetVideoById
{
    public class GetVideoByIdResult
    {
        /// <summary>
        /// Токен видео-вложения
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// URL-ы для скачивания или воспроизведения видео
        /// </summary>
        /// <remarks>
        /// Может быть null, если видео недоступно
        /// </remarks>
        public VideoUrls Urls { get; set; }

        /// <summary>
        /// Миниатюра видео
        /// </summary>
        public ImageAttachmentPayload Thumbnail { get; set; }

        /// <summary>
        /// Ширина видео
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота видео
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Длина видео в секундах
        /// </summary>
        public int Duration { get; set; }
    }
}