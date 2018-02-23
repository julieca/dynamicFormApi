using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.Models
{
    public class AttributeDataSource
    {
        public DataSourceType DataType { get; set; }
        public object Data { get; set; }
        public List<DataSourceSchema> DataList { get; set; }
        public List<AttributeDefinitions> GridList { get; set; }
        public List<AttributeDefinitions> GridHeaderList { get; set; }
        public List<ExpandoObject> GridListJson { get; set; }
    }
}
