using System.Text.Json;
using System.Text.Json.Serialization;

namespace MauiApp1.Utility
{
    public class ExtendedDoubleJsonConverter : JsonConverter<double?>
    {
        public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (double.TryParse(reader.GetString(), out double num)) 
            {
                return num;
            } 
            else 
            {
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteNumberValue(value.Value);
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}
