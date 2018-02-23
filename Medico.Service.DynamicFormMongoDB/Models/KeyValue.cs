using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.Models
{
    public class KeyValue
    {
        private dynamic tempValue;
        /*
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        */
        [Required]
        public string Key { get; set; }

       // public dynamic Value { get; set; } = null;
        
        public dynamic Value {
            get {
                return tempValue;
            }
            set {
                //tempValue = value == null ? null : parseData(value);
                if(value == null)
                {
                    tempValue = null;
                }
                else
                {
                    tempValue = parseData(value);
                }

                var a = "aaa";
            }
        } 
        

        private dynamic parseData(dynamic value)
        {
            dynamic resultVal;

            var valType = value.GetType();
           
            if (valType == typeof(Int64))
            {
                resultVal = Convert.ToInt16(value);
            }
            else if (valType == typeof(String))
            {
                if(Guid.TryParse(value, out Guid uuid))
                {
                    resultVal = uuid;
                }
                else
                {
                    resultVal = value;
                }
            }
            else if (valType == typeof(JObject))
            {
                resultVal = value.ToObject<ExpandoObject>();
            }
            else if (valType == typeof(JArray))
            {
                resultVal = new List<dynamic>();
                var tempList = value.ToObject<List<dynamic>>();
                foreach (var item in tempList)
                {
                    resultVal.Add(parseData(item));
                }
            }
            else
            {
                resultVal = value;
            }
            return resultVal;
        }
    }
}
