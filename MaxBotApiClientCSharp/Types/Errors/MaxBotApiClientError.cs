namespace MaxBotApiClientCSharp.Types.Errors
{
    /// <summary>
    /// Сведения об ошибке, возникшей при выполнении запроса к API
    /// </summary>
    /// <remarks>
    /// В случае, если не удалось выполнить десериализацию ответа, код ошибки - код ответа, а сообщение об ошибке - причина, которая обычно отправляется сервером вместе с кодом ответа
    /// </remarks>
    public class MaxBotApiClientError
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string Message { get; set; }

        public override string ToString()
        {
            return $"При выполнении запроса произошла ошибка. Код ошибки: '{Code}'. Сообщение об ошибке: '{Message}'.";
        }
    }
}
