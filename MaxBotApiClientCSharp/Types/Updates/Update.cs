#region

using System;
using System.Text.Json.Serialization;
using CoreLib.CORE.Helpers.Converters;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Updates
{
    /// <summary>
    /// Событие
    /// </summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "update_type")]
    [JsonDerivedType(typeof(BotAddedToChatUpdate), "bot_added")]
    [JsonDerivedType(typeof(BotRemovedFromChatUpdate), "bot_removed")]
    [JsonDerivedType(typeof(BotStartedUpdate), "bot_started")]
    [JsonDerivedType(typeof(BotStoppedUpdate), "bot_stopped")]
    [JsonDerivedType(typeof(ChatTitleChangedUpdate), "chat_title_changed")]
    [JsonDerivedType(typeof(DialogClearedUpdate), "dialog_cleared")]
    [JsonDerivedType(typeof(DialogMutedUpdate), "dialog_muted")]
    [JsonDerivedType(typeof(DialogRemovedUpdate), "dialog_removed")]
    [JsonDerivedType(typeof(DialogUnmutedUpdate), "dialog_unmuted")]
    [JsonDerivedType(typeof(MessageCallbackUpdate), "message_callback")]
    [JsonDerivedType(typeof(MessageCreatedUpdate), "message_created")]
    [JsonDerivedType(typeof(MessageEditedUpdate), "message_edited")]
    [JsonDerivedType(typeof(MessageRemovedUpdate), "message_removed")]
    [JsonDerivedType(typeof(UserAddedToChatUpdate), "user_added")]
    [JsonDerivedType(typeof(UserRemovedFromChatUpdate), "user_removed")]
    public abstract class Update
    {
        [JsonConstructor]
        protected Update(UpdateType updateType)
        {
            UpdateType = updateType;
        }

        /// <summary>
        /// Тип обновления
        /// </summary>
        [JsonIgnore]
        public UpdateType UpdateType { get; }

        /// <summary>
        /// Время, когда произошло событие
        /// </summary>
        [UnixTimestampConverter]
        public DateTime Timestamp { get; set; }
    }
}