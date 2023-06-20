using System.Text.Json;
using System.Text.Json.Serialization;

namespace webapi
{
    internal sealed class JsonToByteArrayConverter : JsonConverter<byte[]?>
    {
        // Converts base64 encoded string to byte[].
        public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {


                short[] sByteArray = JsonSerializer.Deserialize<short[]>(ref reader);
                byte[] value = new byte[sByteArray.Length];
                for (int i = 0; i < sByteArray.Length; i++)
                {
                    value[i] = (byte)sByteArray[i];
                }

                return value;
            }
            catch
            {
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (var val in value)
            {
                writer.WriteNumberValue(val);
            }

            writer.WriteEndArray();
        }
    }
}
