using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.Models
{
    public class FormAttributes
    {
        public string FormTitle { get; set; }
        public int ColumnCount { get; set; }
        public string OnSuccessRedirect { get; set; }
        public List<string> Scripts { get; set; } = new List<string>();
        public List<AttributeSetDefinition> AttributeSets { get; set; } = new List<AttributeSetDefinition>();

    }
}
