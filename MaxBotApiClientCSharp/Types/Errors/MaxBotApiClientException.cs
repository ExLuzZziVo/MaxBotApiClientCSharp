#region

using System;

#endregion

namespace MaxBotApiClientCSharp.Types.Errors
{
    /// <summary>
    /// Исключение, выбрасываемое при возникновении ошибки при выполнении запроса к API
    /// </summary>
    public class MaxBotApiClientException: Exception
    {
        internal MaxBotApiClientException(MaxBotApiClientError error): base(error.ToString())
        {
            Error = error;
        }

        public MaxBotApiClientError Error { get; }
    }
}
