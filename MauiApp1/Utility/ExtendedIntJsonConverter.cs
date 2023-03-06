using System.Text.Json;
using System.Text.Json.Serialization;

namespace MauiApp1.Utility
{
    public class ExtendedIntJsonConverter : JsonConverter<int?>
    {
        public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (int.TryParse(reader.GetString(), out int num)) 
            {
                return num;
            } 
            else 
            {
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
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
