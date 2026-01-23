#region

using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using MaxBotApiClientCSharp.Types;
using MaxBotApiClientCSharp.Types.Enums;
using MaxBotApiClientCSharp.Types.Operations;
using MaxBotApiClientCSharp.Types.Operations.Messages.GetMessages;
using MaxBotApiClientCSharp.Types.Operations.Messages.GetVideoById;
using MaxBotApiClientCSharp.Types.Operations.Messages.SendCallbackAnswer;
using MaxBotApiClientCSharp.Types.Operations.Messages.SendMessage;

#endregion

namespace MaxBotApiClientCSharp.Client
{
    public partial class MaxBotApiClient
    {
        /// <summary>
        /// Запрашивает массив сообщений из указанного чата
        /// </summary>
        /// <param name="chatId">ID чата</param>
        /// <param name="count">Максимальное количество сообщений в ответе. По умолчанию: 50</param>
        /// <param name="from">Время начала для запрашиваемых сообщений</param>
        /// <param name="to">Время окончания для запрашиваемых сообщений</param>
        /// <returns>Массив сообщений из указанного чата</returns>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="count"/> должен лежать в диапазоне [1-100]</exception>
        public virtual async Task<GetMessagesResult> GetMessagesAsync(long chatId, int count = 50,
            DateTime? from = null, DateTime? to = null)
        {
            if (!count.IsInRange(1, 100))
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            var isToLessThanFrom = to < from;

            return await ExecuteAsync<GetMessagesResult>($"/messages?chat_id={chatId}", HttpMethod.Get,
                new GetMessagesOperation
                {
                    Count = count,
                    From = isToLessThanFrom ? to : from,
                    To = isToLessThanFrom ? from : to
                });
        }

        /// <summary>
        /// Запрашивает информацию о запрошенных сообщения
        /// </summary>
        /// <param name="messageIds">ID сообщений</param>
        /// <returns>Информацию о запрошенных сообщения</returns>
        /// <exception cref="ArgumentException">Кол-во непустых элементов в коллекции <paramref name="messageIds"/> должно лежать в диапазоне [1-100]</exception>
        public virtual async Task<GetMessagesResult> GetMessagesAsync(params string[] messageIds)
        {
            messageIds = messageIds?.Where(id => !id.IsNullOrEmptyOrWhiteSpace()).ToArray();

            if (messageIds == null || !messageIds.Length.IsInRange(1, 100))
            {
                throw new ArgumentException(string.Format(
                    ValidationStrings.ResourceManager.GetString("CollectionRangeLengthError"), nameof(messageIds), 1,
                    100));
            }

            return await ExecuteAsync<GetMessagesResult>($"/messages?message_ids={string.Join(",", messageIds)}",
                HttpMethod.Get,
                new GetMessagesOperation
                {
                    Count = messageIds.Length
                });
        }

        /// <summary>
        /// Отправляет сообщение пользователю
        /// </summary>
        /// <param name="userId">ИД пользователя</param>
        /// <param name="messageBody">Содержимое сообщения</param>
        /// <param name="disableLinkPreview">Нужно ли генерировать превью для ссылок в тексте сообщения. По умолчанию: true</param>
        /// <returns>Сообщение в чате</returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="messageBody"/> обязателен</exception>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="messageBody.Text"/> должен иметь длину не более 4000</exception>
        /// <exception cref="ArgumentException">Параметр <paramref name="messageBody.Attachments"/> имеет несколько вложений, одно или несколько из которых должны быть единственными</exception>
        public virtual async Task<SendMessageResult> SendMessageToUserAsync(long userId, NewMessageBody messageBody,
            bool disableLinkPreview = true)
        {
            ValidateMessageBody(messageBody);

            return await ExecuteAsync<SendMessageResult>(
                $"/messages?user_id={userId}&disable_link_preview={disableLinkPreview.ToString().ToLower()}",
                HttpMethod.Post, messageBody);
        }

        /// <summary>
        /// Отправляет сообщение в чат
        /// </summary>
        /// <param name="chatId">ИД чата</param>
        /// <param name="messageBody">Содержимое сообщения</param>
        /// <param name="disableLinkPreview">Нужно ли генерировать превью для ссылок в тексте сообщения. По умолчанию: true</param>
        /// <returns>Сообщение в чате</returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="messageBody"/> обязателен</exception>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="messageBody.Text"/> должен иметь длину не более 4000</exception>
        /// <exception cref="ArgumentException">Параметр <paramref name="messageBody.Attachments"/> имеет несколько вложений, одно или несколько из которых должны быть единственными</exception>
        public virtual async Task<SendMessageResult> SendMessageToChatAsync(long chatId, NewMessageBody messageBody,
            bool disableLinkPreview = true)
        {
            ValidateMessageBody(messageBody);

            return await ExecuteAsync<SendMessageResult>(
                $"/messages?chat_id={chatId}&disable_link_preview={disableLinkPreview.ToString().ToLower()}",
                HttpMethod.Post, messageBody);
        }

        /// <summary>
        /// Редактирует сообщение в чате
        /// </summary>
        /// <param name="messageId">ID редактируемого сообщения</param>
        /// <param name="messageBody">Содержимое сообщения</param>
        /// <returns>Результат выполнения операции</returns>
        /// <remarks>
        /// <para>Если поле <paramref name="messageBody.Attachments"/> равно null, вложения текущего сообщения не изменяются. Если в этом поле передан пустой список, все вложения будут удалены</para>
        /// <para>С помощью метода можно отредактировать сообщения, которые отправлены менее 24 часов назад</para>
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// <para>Параметр <paramref name="messageId"/> обязателен</para>
        /// <para>Параметр <paramref name="messageBody"/> обязателен</para>
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="messageBody.Text"/> должен иметь длину не более 4000</exception>
        /// <exception cref="ArgumentException">Параметр <paramref name="messageBody.Attachments"/> имеет несколько вложений, одно или несколько из которых должны быть единственными</exception>
        public virtual async Task<CommonOperationResult> EditMessageAsync(string messageId, NewMessageBody messageBody)
        {
            if (messageId.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(messageId));
            }

            ValidateMessageBody(messageBody);

            return await ExecuteAsync<CommonOperationResult>($"/messages?message_id={messageId}", HttpMethod.Put,
                messageBody);
        }

        private static void ValidateMessageBody(NewMessageBody messageBody)
        {
            if (messageBody == null)
            {
                throw new ArgumentNullException(nameof(messageBody));
            }

            if (messageBody.Text?.Length > 4000)
            {
                throw new ArgumentOutOfRangeException(string.Format(
                    ValidationStrings.ResourceManager.GetString("StringMaxLengthError"), nameof(messageBody.Text)));
            }

            if (messageBody.Attachments?.Length > 1)
            {
                if (messageBody.Attachments.Any(a =>
                        a.Type
                            is AttachmentType.Audio
                            or AttachmentType.Contact
                            or AttachmentType.File
                            or AttachmentType.Sticker))
                {
                    throw new ArgumentException(
                        "Вложения со следующими типами должны быть единственными: Audio, Contact, File, Sticker.",
                        nameof(messageBody.Attachments));
                }
            }
        }

        /// <summary>
        /// Удаляет сообщение в диалоге или чате, если бот имеет разрешение на удаление сообщений
        /// </summary>
        /// <param name="messageId">ID удаляемого сообщения</param>
        /// <returns>Результат выполнения операции</returns>
        /// <remarks>
        /// С помощью метода можно удалять сообщения, которые отправлены менее 24 часов назад
        /// </remarks>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="messageId"/> обязателен</exception>
        public virtual async Task<CommonOperationResult> DeleteMessageAsync(string messageId)
        {
            if (messageId.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(messageId));
            }

            return await ExecuteAsync<CommonOperationResult>($"/messages?message_id={messageId}", HttpMethod.Delete);
        }

        /// <summary>
        /// Получает сообщение по его ID
        /// </summary>
        /// <param name="messageId">ID сообщения</param>
        /// <returns>Сообщение</returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="messageId"/> обязателен</exception>
        public virtual async Task<Message> GetMessageAsync(string messageId)
        {
            if (messageId.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(messageId));
            }

            return await ExecuteAsync<Message>($"/messages/{messageId}", HttpMethod.Get);
        }

        /// <summary>
        /// Запрашивает подробную информацию о прикреплённом видео
        /// </summary>
        /// <param name="token">Токен видео-вложения</param>
        /// <returns>Подробную информацию о прикреплённом видео</returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="token"/> обязателен</exception>
        public virtual async Task<GetVideoByIdResult> GetVideoAsync(string token)
        {
            if (token.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(token));
            }

            return await ExecuteAsync<GetVideoByIdResult>($"/videos/{token}", HttpMethod.Get);
        }

        /// <summary>
        /// Отправляет ответ на действие пользователя путем обновления сообщения
        /// </summary>
        /// <param name="callbackId">Идентификатор кнопки, по которой пользователь кликнул</param>
        /// <param name="messageBody">Содержимое сообщения</param>
        /// <returns>Результат выполнения операции</returns>
        /// <exception cref="ArgumentNullException">
        /// <para>Параметр <paramref name="callbackId"/> обязателен</para>
        /// <para>Параметр <paramref name="messageBody"/> обязателен</para>
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Параметр <paramref name="messageBody.Text"/> должен иметь длину не более 4000</exception>
        /// <exception cref="ArgumentException">Параметр <paramref name="messageBody.Attachments"/> имеет несколько вложений, одно или несколько из которых должны быть единственными</exception>
        public virtual async Task<CommonOperationResult> SendCallbackAnswer(string callbackId,
            NewMessageBody messageBody)
        {
            if (callbackId.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(callbackId));
            }

            ValidateMessageBody(messageBody);

            return await ExecuteAsync<CommonOperationResult>($"/answers?callback_id={callbackId}", HttpMethod.Post,
                new SendCallbackAnswerOperation
                {
                    Message = messageBody
                });
        }

        /// <summary>
        /// Отправляет ответ на действие пользователя путем отправки одноразового уведомления
        /// </summary>
        /// <param name="callbackId">Идентификатор кнопки, по которой пользователь кликнул</param>
        /// <param name="notification">Текст одноразового уведомления пользователю</param>
        /// <returns>Результат выполнения операции</returns>
        /// <exception cref="ArgumentNullException">
        /// <para>Параметр <paramref name="callbackId"/> обязателен</para>
        /// <para>Параметр <paramref name="notification"/> обязателен</para>
        /// </exception>
        public virtual async Task<CommonOperationResult> SendCallbackAnswer(string callbackId, string notification)
        {
            if (callbackId.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(callbackId));
            }

            if (notification.IsNullOrEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return await ExecuteAsync<CommonOperationResult>($"/answers?callback_id={callbackId}", HttpMethod.Post,
                new SendCallbackAnswerOperation
                {
                    Notification = notification
                });
        }
    }
}