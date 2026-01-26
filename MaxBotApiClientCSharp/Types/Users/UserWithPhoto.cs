#region

using System.Text.Json.Serialization;

#endregion

namespace MaxBotApiClientCSharp.Types.Users
{
    /// <summary>
    /// Информация о пользователе с фотографией
    /// </summary>
    [JsonDerivedType(typeof(BotInfo))]
    public class UserWithPhoto: User
    {
        /// <summary>
        /// Описание пользователя
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URL аватара
        /// </summary>
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// URL аватара большего размера
        /// </summary>
        [JsonPropertyName("full_avatar_url")]
        public string FullAvatarUrl { get; set; }
    }
}