#region

using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Markups
{
    /// <summary>
    /// Курсив
    /// </summary>
    public class EmphasizedMarkup: MarkupElement
    {
        public EmphasizedMarkup(): base(MarkupType.Emphasized) { }
    }
}