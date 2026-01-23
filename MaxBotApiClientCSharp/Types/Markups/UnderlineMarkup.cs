#region

using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Markups
{
    /// <summary>
    /// Подчеркнутый
    /// </summary>
    public class UnderlineMarkup: MarkupElement
    {
        public UnderlineMarkup(): base(MarkupType.Underline) { }
    }
}