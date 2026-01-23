#region

using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Markups
{
    /// <summary>
    /// Зачеркнутый
    /// </summary>
    public class StrikethroughMarkup: MarkupElement
    {
        public StrikethroughMarkup(): base(MarkupType.Strikethrough) { }
    }
}