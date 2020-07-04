using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.NetCore.Helpers
{
    public class EnumJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (existingValue == null || existingValue == 0 as object)
            {
                return 0;
            }

            var jsonObject = JObject.Load(reader);

            if (jsonObject.Count == 0)
            {
                return 0;
            }

            var value = jsonObject["value"];
            if (value.HasValues)
            {
                return 0;
            }
            else
            {
                return value.Value<int>();
            }

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var propertyName = writer.Path.Split('.');
            var optionModel = new EnumHelper().EnumToOption((Enum)value);

            writer.WriteStartObject();
            writer.WritePropertyName("label");
            serializer.Serialize(writer, optionModel.Label);
            //writer.WriteStartObject();
            writer.WritePropertyName("value");
            serializer.Serialize(writer, optionModel.Value);
            writer.WriteEndObject();
        }
    }
}
