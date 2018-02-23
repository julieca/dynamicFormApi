using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.Models
{
    public class AttributeSetDefinition : KeyValue
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public int ColSpan { get; set; } = 1;
        public List<AttributeDefinitions> Attributes { get; set; } = new List<AttributeDefinitions>();

    }
}
