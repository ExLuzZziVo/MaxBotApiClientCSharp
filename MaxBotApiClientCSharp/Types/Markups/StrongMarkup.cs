#region

using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Markups
{
    /// <summary>
    /// Жирный
    /// </summary>
    public class StrongMarkup: MarkupElement
    {
        public StrongMarkup(): base(MarkupType.Strong) { }
    }
}