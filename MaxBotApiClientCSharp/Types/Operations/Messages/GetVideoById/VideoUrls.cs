namespace MaxBotApiClientCSharp.Types.Operations.Messages.GetVideoById
{
    /// <summary>
    /// URL-ы для скачивания или воспроизведения видео
    /// </summary>
    public class VideoUrls
    {
        /// <summary>
        /// URL видео в разрешении 1080p, если доступно
        /// </summary>
        public string Mp4_1080 { get; set; }

        /// <summary>
        /// URL видео в разрешении 720p, если доступно
        /// </summary>
        public string Mp4_720 { get; set; }

        /// <summary>
        /// URL видео в разрешении 480p, если доступно
        /// </summary>
        public string Mp4_480 { get; set; }

        /// <summary>
        /// URL видео в разрешении 360p, если доступно
        /// </summary>
        public string Mp4_360 { get; set; }

        /// <summary>
        /// URL видео в разрешении 240p, если доступно
        /// </summary>
        public string Mp4_240 { get; set; }

        /// <summary>
        /// URL видео в разрешении 144p, если доступно
        /// </summary>
        public string Mp4_144 { get; set; }

        /// <summary>
        /// URL трансляции, если доступна
        /// </summary>
        public string Hls { get; set; }
    }
}
