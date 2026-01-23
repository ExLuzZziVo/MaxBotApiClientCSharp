#region

using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Markups
{
    /// <summary>
    /// Ссылка
    /// </summary>
    public class LinkMarkup: MarkupElement
    {
        public LinkMarkup(): base(MarkupType.Link) { }

        /// <summary>
        /// URL ссылки
        /// </summary>
        public string Url { get; set; }
    }
}