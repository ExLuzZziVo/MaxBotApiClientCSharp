#region

using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Helpers;
using MaxBotApiClientCSharp.Types;
using MaxBotApiClientCSharp.Types.Attachments.Request.Payloads;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Operations;
using MaxBotApiClientCSharp.Types.Operations.Chats;
using MaxBotApiClientCSharp.Types.Operations.Chats.Administrators.GetGroupChatAdministrators;
using MaxBotApiClientCSharp.Types.Operations.Chats.Administrators.SetGroupChatAdministrators;
using MaxBotApiClientCSharp.Types.Operations.Chats.EditGroupChat;
using MaxBotApiClientCSharp.Types.Operations.Chats.GetAllGroupChats;
using MaxBotApiClientCSharp.Types.Operations.Chats.Members.AddGroupChatMembers;
using MaxBotApiClientCSharp.Types.Operations.Chats.Members.DeleteGroupChatMember;
using MaxBotApiClientCSharp.Types.Operations.Chats.Members.GetGroupChatMembers;
using MaxBotApiClientCSharp.Types.Operations.Chats.PinnedMessages.GetPinnedMessage;
using MaxBotApiClientCSharp.Types.Operations.Chats.PinnedMessages.PinMessage;
using MaxBotApiClientCSharp.Types.Operations.Chats.SendActionToGroupChat;
using MaxBotApiClientCSharp.Types.Users;

#endregion

namespace MaxBotApiClientCSharp.Client
{
    public partial class MaxBotApiClient
    {
        /// <summary>
        /// Запрос списка групповых чатов, в которых участвовал бот
        /// </summary>
        /// <param name="count">Количество запрашиваемых чатов. По умолчанию: 50</param>
        /// <param name="marker">Указатель на следующую страницу данных. Для первой страницы: null</param>
        /// <returns>Список групповых чатов, в которых участвовал бот</returns>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="count"/> должен лежать в диапазоне [1-100]</exception>
        public virtual async Task<ChatsOperationResult> GetAllGroupChatsAsync(int count = 50, long? marker = null)
        {
            if (!count.IsInRange(1, 100))
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return await ExecuteAsync<ChatsOperationResult>("/chats", HttpMethod.Get, new GetAllGroupChatsOperation
            {
                Count = count,
                Marker = marker
            });
        }

        /// <summary>
        /// Запрашивает информацию о групповом чате по его идентификатору из пригласительной ссылки
        /// </summary>
        /// <param name="chatLink">Уникальный идентификатор чата из пригласительной ссылки. Может начинаться с @, содержит латиницу, цифры, _ и -</param>
        /// <returns>Информацию о групповом чате по его идентификатору из пригласительной ссылки</returns>
        /// <exception cref="ArgumentException">Параметр <paramref name="chatLink"/> может начинаться с @, содержит латиницу, цифры, _ и -</exception>
        public virtual async Task<Chat> GetGroupChatAsync(string chatLink)
        {
            if (chatLink.IsNullOrEmptyOrWhiteSpace() || !Regex.IsMatch(chatLink, RegularExpressions.ChatLinkExpression))
            {
                throw new ArgumentException(
                    string.Format(ValidationStrings.ResourceManager.GetString("StringFormatError"), nameof(chatLink)),
                    nameof(chatLink));
            }

            return await ExecuteAsync<Chat>($"/chats/{chatLink}", HttpMethod.Get);
        }

        /// <summary>
        /// Запрашивает информацию о групповом чате по его ID
        /// </summary>
        /// <param name="chatId">ID запрашиваемого чата</param>
        /// <returns>Информацию о групповом чате по его ID</returns>
        public virtual async Task<Chat> GetGroupChatAsync(long chatId)
        {
            return await ExecuteAsync<Chat>($"/chats/{chatId}", HttpMethod.Get);
        }

        /// <summary>
        /// Редактирует информацию о групповом чате
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="icon">Изображение чата</param>
        /// <param name="title">Название</param>
        /// <param name="pin">ID сообщения для закрепления в чате</param>
        /// <param name="notify">Флаг, указывающий будут ли участники чата уведомлены об изменении. По умолчанию: true</param>
        /// <returns>Отредактированный чат</returns>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="title"/> должен иметь длину [1-200]</exception>
        public virtual async Task<Chat> EditGroupChatAsync(long chatId, ImageAttachmentRequestPayload icon = null,
            string title = null, string pin = null, bool notify = true)
        {
            if (title != null && !title.Length.IsInRange(1, 200))
            {
                throw new ArgumentOutOfRangeException(nameof(title));
            }

            return await ExecuteAsync<Chat>($"/chats/{chatId}", HttpMethodPatch, new EditGroupChatOperation
            {
                Icon = icon,
                Title = title,
                Pin = pin,
                Notify = notify
            });
        }

        /// <summary>
        /// Удаляет групповой чат для всех участников
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <returns>Результат выполнения операции</returns>
        public virtual async Task<CommonOperationResult> DeleteGroupChatAsync(long chatId)
        {
            return await ExecuteAsync<CommonOperationResult>($"/chats/{chatId}", HttpMethod.Delete);
        }

        /// <summary>
        /// Отправляет действие бота в групповой чат
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="action">Действие, отправляемое участникам чата</param>
        /// <returns>Результат выполнения операции</returns>
        public virtual async Task<CommonOperationResult> SendActionToGroupChatAsync(long chatId, SenderAction action)
        {
            return await ExecuteAsync<CommonOperationResult>($"/chats/{chatId}/actions", HttpMethod.Post,
                new SendActionToGroupChatOperation
                {
                    Action = action
                });
        }

        /// <summary>
        /// Запрашивает закреплённое сообщение в групповом чате
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <returns>Закреплённое сообщение в групповом чате</returns>
        public virtual async Task<GetPinnedMessageResult> GetPinnedMessageAsync(long chatId)
        {
            return await ExecuteAsync<GetPinnedMessageResult>($"/chats/{chatId}/pin", HttpMethod.Get);
        }

        /// <summary>
        /// Закрепляет сообщение в групповом чате
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="messageId">ID сообщения, которое нужно закрепить</param>
        /// <param name="notify">Флаг, указывающий будут ли участники чата уведомлены об изменении. По умолчанию: true</param>
        /// <returns>Результат выполнения операции</returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="messageId"/> обязателен</exception>
        public virtual async Task<CommonOperationResult> PinMessageAsync(long chatId, string messageId,
            bool notify = true)
        {
            if (messageId.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(messageId));
            }

            return await ExecuteAsync<CommonOperationResult>($"/chats/{chatId}/pin", HttpMethod.Put,
                new PinMessageOperation
                {
                    MessageId = messageId,
                    Notify = notify
                });
        }

        /// <summary>
        /// Удаляет закреплённое сообщение в групповом чате
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <returns>Результат выполнения операции</returns>
        public virtual async Task<CommonOperationResult> DeletePinnedMessageAsync(long chatId)
        {
            return await ExecuteAsync<CommonOperationResult>($"/chats/{chatId}/pin", HttpMethod.Delete);
        }

        /// <summary>
        /// Запрашивает информацию о членстве текущего бота в групповом чате
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <returns>Информацию о членстве текущего бота в групповом чате</returns>
        public virtual async Task<BotInfo> GetBotGroupChatInfoAsync(long chatId)
        {
            return await ExecuteAsync<BotInfo>($"/chats/{chatId}/members/me", HttpMethod.Get);
        }

        /// <summary>
        /// Удаляет бота из участников группового чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <returns>Результат выполнения операции</returns>
        public virtual async Task<CommonOperationResult> DeleteBotFromGroupChatAsync(long chatId)
        {
            return await ExecuteAsync<CommonOperationResult>($"/chats/{chatId}/members/me", HttpMethod.Delete);
        }

        /// <summary>
        /// Запрашивает список всех администраторов группового чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="marker">Указатель на следующую страницу данных. Для первой страницы: null</param>
        /// <returns>Список всех администраторов группового чата</returns>
        /// <remarks>
        /// Бот должен быть администратором в запрашиваемом чате
        /// </remarks>
        public virtual async Task<ChatMembersOperationResult> GetGroupChatAdminsAsync(long chatId, long? marker = null)
        {
            return await ExecuteAsync<ChatMembersOperationResult>($"/chats/{chatId}/members/admins", HttpMethod.Get,
                new GetGroupChatAdministratorsOperation
                {
                    Marker = marker
                });
        }

        /// <summary>
        /// Назначает администраторов группового чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="chatAdmins">Список пользователей, которые получат права администратора чата</param>
        /// <returns>Результат выполнения операции</returns>
        /// <exception cref="ArgumentException">Параметр <paramref name="chatAdmins"/> обязателен и должен содержать хотя бы один элемент</exception>
        public virtual async Task<CommonOperationResult> SetGroupChatAdminsAsync(long chatId,
            params ChatAdmin[] chatAdmins)
        {
            if (chatAdmins == null || chatAdmins.Length == 0)
            {
                throw new ArgumentException(string.Format(
                    ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"), nameof(chatAdmins), 1));
            }

            return await ExecuteAsync<CommonOperationResult>($"/chats/{chatId}/members/admins", HttpMethod.Post,
                new SetGroupChatAdministratorsOperation
                {
                    Admins = chatAdmins
                });
        }

        /// <summary>
        /// Отменяет права администратора у пользователя в групповом чате, лишая его административных привилегий
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="userId">ID пользователя</param>
        /// <returns>Результат выполнения операции</returns>
        public virtual async Task<CommonOperationResult> RemoveAdminPermissionsAsync(long chatId, long userId)
        {
            return await ExecuteAsync<CommonOperationResult>($"/chats/{chatId}/members/admins/{userId}",
                HttpMethod.Delete);
        }

        /// <summary>
        /// Получает список участников группового чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="userIds">Список ID пользователей, чье членство нужно получить</param>
        /// <returns>Список участников группового чата</returns>
        /// <exception cref="ArgumentException">Параметр <paramref name="userIds"/> обязателен и должен содержать хотя бы один элемент</exception>
        public virtual async Task<ChatMembersOperationResult> GetGroupChatMembersAsync(long chatId,
            params long[] userIds)
        {
            if (userIds == null || userIds.Length == 0)
            {
                throw new ArgumentException(string.Format(
                    ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"), nameof(userIds), 1));
            }

            return await ExecuteAsync<ChatMembersOperationResult>($"/chats/{chatId}/members", HttpMethod.Get,
                new GetGroupChatMembersOperation
                {
                    UserIds = userIds
                });
        }

        /// <summary>
        /// Получает список участников группового чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="count">Количество запрашиваемых участников. По умолчанию: 20</param>
        /// <param name="marker">Указатель на следующую страницу данных. Для первой страницы: null</param>
        /// <returns>Список участников группового чата</returns>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="count"/> должен лежать в диапазоне [1-100]</exception>
        public virtual async Task<ChatMembersOperationResult> GetGroupChatMembersAsync(long chatId, int count = 20,
            long? marker = null)
        {
            if (!count.IsInRange(1, 100))
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return await ExecuteAsync<ChatMembersOperationResult>($"/chats/{chatId}/members", HttpMethod.Get,
                new GetGroupChatMembersOperation
                {
                    Count = count,
                    Marker = marker
                });
        }

        /// <summary>
        /// Добавляет участников в групповой чат
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="userIds">Список ID пользователей, которых нужно добавить в чат</param>
        /// <returns>Результат выполнения операции</returns>
        /// <exception cref="ArgumentException">Параметр <paramref name="userIds"/> обязателен и должен содержать хотя бы один элемент</exception>
        /// <remarks>
        /// Для этого могут потребоваться дополнительные права
        /// </remarks>
        public virtual async Task<CommonOperationResult> AddGroupChatMembersAsync(long chatId, params long[] userIds)
        {
            if (userIds == null || userIds.Length == 0)
            {
                throw new ArgumentException(string.Format(
                    ValidationStrings.ResourceManager.GetString("CollectionMinLengthError"), nameof(userIds), 1));
            }

            return await ExecuteAsync<CommonOperationResult>($"/chats/{chatId}/members", HttpMethod.Post,
                new AddGroupChatMembersOperation
                {
                    UserIds = userIds
                });
        }

        /// <summary>
        /// Удаляет участника из группового чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="userId">ID пользователя, которого нужно удалить из чата</param>
        /// <param name="block">Флаг, указывающий что пользователь будет заблокирован в чате. По умолчанию: false</param>
        /// <returns>Результат выполнения операции</returns>
        /// <remarks>
        /// Для этого могут потребоваться дополнительные права
        /// </remarks>
        public virtual async Task<CommonOperationResult> DeleteGroupChatMemberAsync(long chatId, long userId,
            bool block = false)
        {
            return await ExecuteAsync<CommonOperationResult>($"/chats/{chatId}/members", HttpMethod.Delete,
                new DeleteGroupChatMemberOperation
                {
                    UserId = userId,
                    Block = block
                });
        }
    }
}
