#region

using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Markups
{
    /// <summary>
    /// Моноширинный
    /// </summary>
    public class MonospacedMarkup: MarkupElement
    {
        public MonospacedMarkup(): base(MarkupType.Monospaced) { }
    }
}