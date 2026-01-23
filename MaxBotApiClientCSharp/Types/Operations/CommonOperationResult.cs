namespace MaxBotApiClientCSharp.Types.Operations
{
    public class CommonOperationResult
    {
        /// <summary>
        /// Флаг, указывающий является ли запрос успешным
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Объяснительное сообщение, если результат не был успешным
        /// </summary>
        public string Message { get; set; }
    }
}