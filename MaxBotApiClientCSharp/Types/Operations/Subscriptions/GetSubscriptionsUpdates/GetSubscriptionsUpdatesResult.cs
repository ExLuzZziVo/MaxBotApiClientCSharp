#region

using MaxBotApiClientCSharp.Types.Updates;

#endregion

namespace MaxBotApiClientCSharp.Types.Operations.Subscriptions.GetSubscriptionsUpdates
{
    public class GetSubscriptionsUpdatesResult
    {
        /// <summary>
        /// Список запрашиваемых обновлений
        /// </summary>
        public Update[] Updates { get; set; }

        /// <summary>
        /// Указатель на следующую страницу запрашиваемых данных
        /// </summary>
        public long? Marker { get; set; }
    }
}