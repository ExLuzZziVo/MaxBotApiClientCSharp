using System.Collections.Generic;

namespace MaxBotApiClientCSharp.Types.Operations.Upload.UploadData
{
    public class UploadDataResult
    {
        /// <summary>
        /// Токен загруженного файла
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Токены, полученные после загрузки изображений
        /// </summary>
        public IDictionary<string, ImageToken> Photos { get; set; }
    }
}
