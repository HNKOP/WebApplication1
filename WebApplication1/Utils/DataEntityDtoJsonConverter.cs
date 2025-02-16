using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication1.Entities;

namespace WebApplication1.Utils
{
    public class DataEntityDtoJsonConverter : JsonConverter<List<DataEntityDto>>
    {
        public override List<DataEntityDto> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            List<DataEntityDto?> dataEntities = new List<DataEntityDto?>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }

                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    reader.Read();
                }

                int.TryParse(reader.GetString(), out int code);

                reader.Read();

                var value = reader.GetString();

                DataEntityDto dataEntityDto = new DataEntityDto() { Code = code, Value = value };
                dataEntities.Add(dataEntityDto);

                reader.Read();

                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    reader.Read();
                }
            }

            return dataEntities;

        }

        public override void Write(Utf8JsonWriter writer, List<DataEntityDto> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
