#region

using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Attachments.Request
{
    /// <summary>
    /// Запрос на прикрепление местоположения
    /// </summary>
    public class LocationAttachmentRequest: AttachmentRequest
    {
        /// <summary>
        /// Запрос на прикрепление местоположения
        /// </summary>
        /// <param name="latitude">Широта</param>
        /// <param name="longitude">Долгота</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>Параметр <paramref name="latitude"/> должен лежать в диапазоне [-90-90]</para>
        /// <para>Параметр <paramref name="longitude"/> должен лежать в диапазоне [-180-180]</para>
        /// </exception>
        public LocationAttachmentRequest(double latitude, double longitude): base(AttachmentType.Location)
        {
            if (!latitude.IsInRange(-90, 90))
            {
                throw new ArgumentOutOfRangeException(nameof(latitude));
            }

            if (!longitude.IsInRange(-180, 180))
            {
                throw new ArgumentOutOfRangeException(nameof(longitude));
            }

            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Широта
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(-90, 90, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public double Latitude { get; }

        /// <summary>
        /// Долгота
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(-180, 180, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public double Longitude { get; }
    }
}