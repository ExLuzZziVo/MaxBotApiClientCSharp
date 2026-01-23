#region

using System;
using System.Text.Json.Serialization;

#endregion

namespace MaxBotApiClientCSharp.Helpers
{
    public class TwoDimensionalArrayConverterAttribute<T>: JsonConverterAttribute
    {
        public override JsonConverter CreateConverter(Type typeToConvert)
        {
            if (typeToConvert.IsArray && typeToConvert.GetArrayRank() == 2)
            {
                return new TwoDimensionalArrayConverter<T>();
            }

            throw new NotSupportedException(
                "This converter only supports two-dimensional arrays.");
        }
    }
}
