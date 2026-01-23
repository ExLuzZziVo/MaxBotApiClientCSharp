#region

using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Operations.Upload.GetUploadUrl;
using MaxBotApiClientCSharp.Types.Operations.Upload.UploadData;

#endregion

namespace MaxBotApiClientCSharp.Client
{
    public partial class MaxBotApiClient
    {
        /// <summary>
        /// Получает URL для последующей загрузки файла
        /// </summary>
        /// <param name="uploadType">Тип загружаемого файла</param>
        /// <returns>URL для последующей загрузки файла</returns>
        public virtual async Task<GetUploadUrlResult> GetUploadUrlAsync(UploadType uploadType)
        {
            return await ExecuteAsync<GetUploadUrlResult>($"/uploads?type={uploadType.ToString("G").ToLower()}",
                HttpMethod.Post);
        }

        /// <summary>
        /// Загружает файл по ссылке, полученной с помощью метода <see cref="GetUploadUrlAsync"/>
        /// </summary>
        /// <param name="uploadUrl">URL для загрузки файла, полученный с помощью метода <see cref="GetUploadUrlAsync"/></param>
        /// <param name="fileName">Имя файла</param>
        /// <param name="data">Данные файла в виде массива байт</param>
        /// <returns>Результат загрузки файла</returns>
        /// <exception cref="ArgumentException">Параметр <paramref name="uploadUrl"/> обязателен и должен соответствовать регулярному выражению <see cref="RegexExtensions.UrlPattern"/></exception>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="fileName"/> обязателен</exception>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="data"/> обязателен и должен иметь размер не более 4 ГБ</exception>
        public virtual async Task<UploadDataResult> UploadDataAsync(string uploadUrl, string fileName, byte[] data)
        {
            if (uploadUrl.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(uploadUrl, RegexExtensions.UrlPattern))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"), nameof(uploadUrl)),
                    nameof(uploadUrl));
            }

            if (fileName.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (data == null || !data.LongLength.IsInRange(1, 4294967296))
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(ValidationStrings.ResourceManager.GetString("FileMaxSizeError"), nameof(data),
                        "4 ГБ"),
                    nameof(data));
            }

            using var multipartFormDataContent = new MultipartFormDataContent();

            var byteArrayContent = new ByteArrayContent(data);

            multipartFormDataContent.Add(byteArrayContent, "data", fileName);

            using var response = await HttpClientInstance.PostAsync(uploadUrl, multipartFormDataContent);

            return await ProcessResponseAsync<UploadDataResult>(response);
        }

        /// <summary>
        /// Загружает файл по ссылке, полученной с помощью метода <see cref="GetUploadUrlAsync"/>
        /// </summary>
        /// <param name="uploadUrl">URL для загрузки файла, полученный с помощью метода <see cref="GetUploadUrlAsync"/></param>
        /// <param name="filePath">Полный путь к файлу</param>
        /// <returns>Результат загрузки файла</returns>
        public virtual async Task<UploadDataResult> UploadDataAsync(string uploadUrl, string filePath)
        {
            var fileName = Path.GetFileName(filePath);

            var data = File.ReadAllBytes(filePath);

            return await UploadDataAsync(uploadUrl, fileName, data);
        }

        /// <summary>
        /// Загружает файл
        /// </summary>
        /// <param name="uploadType">Тип загружаемого файла</param>
        /// <param name="fileName">Имя файла</param>
        /// <param name="data">Данные файла в виде массива байт</param>
        /// <returns>Результат загрузки файла</returns>
        public virtual async Task<UploadDataResult> UploadFileAsync(UploadType uploadType, string fileName, byte[] data)
        {
            var uploadUrlResult = await GetUploadUrlAsync(uploadType);

            return await UploadDataAsync(uploadUrlResult.Url, fileName, data);
        }

        /// <summary>
        /// Загружает файл
        /// </summary>
        /// <param name="uploadType">Тип загружаемого файла</param>
        /// <param name="filePath">Полный путь к файлу</param>
        /// <returns>Результат загрузки файла</returns>
        public virtual async Task<UploadDataResult> UploadFileAsync(UploadType uploadType, string filePath)
        {
            var uploadUrlResult = await GetUploadUrlAsync(uploadType);

            return await UploadDataAsync(uploadUrlResult.Url, filePath);
        }
    }
}