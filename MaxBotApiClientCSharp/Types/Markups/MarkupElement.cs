#region

using System.Text.Json.Serialization;
using MaxBotApiClientCSharp.Types.Enums;

#endregion

namespace MaxBotApiClientCSharp.Types.Markups
{
    /// <summary>
    /// Элемент разметки Markup
    /// </summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(EmphasizedMarkup), "emphasized")]
    [JsonDerivedType(typeof(LinkMarkup), "link")]
    [JsonDerivedType(typeof(MonospacedMarkup), "monospaced")]
    [JsonDerivedType(typeof(StrikethroughMarkup), "strikethrough")]
    [JsonDerivedType(typeof(StrongMarkup), "strong")]
    [JsonDerivedType(typeof(UnderlineMarkup), "underline")]
    [JsonDerivedType(typeof(UserMentionMarkup), "user_mention")]
    public class MarkupElement
    {
        [JsonConstructor]
        protected MarkupElement(MarkupType type)
        {
            Type = type;
        }

        /// <summary>
        /// Тип форматирования
        /// </summary>
        [JsonIgnore]
        public MarkupType Type { get; }

        /// <summary>
        /// Индекс начала элемента разметки в тексте
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// Длина элемента разметки
        /// </summary>
        public int Length { get; set; }
    }
}
