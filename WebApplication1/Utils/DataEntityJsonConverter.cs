using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication1.Entities;

namespace WebApplication1.Utils
{
    public class DataEntityJsonConverter : JsonConverter<List<DataEntity>>
    {
        public override List<DataEntity> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            List<DataEntity?> dataEntities = new List<DataEntity?>();

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

                if(!int.TryParse(reader.GetString(), out int code))
                {
                    throw new JsonException("Value can't be parsed into Int32.");
                }

                reader.Read();

                if (reader.TokenType != JsonTokenType.String)
                {
                    throw new JsonException("Value can't be parsed into String.");
                }

                var value = reader.GetString();

                DataEntity dataEntityDto = new DataEntity() { Code = code, Value = value };
                dataEntities.Add(dataEntityDto);

                reader.Read();

                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    reader.Read();
                }
            }

            return dataEntities;

        }

        public override void Write(Utf8JsonWriter writer, List<DataEntity> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
