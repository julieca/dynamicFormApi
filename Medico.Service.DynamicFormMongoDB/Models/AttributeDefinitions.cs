using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.Models
{
    public class AttributeDefinitions
    {
        public int Sequence { get; set; }
        public string ID { get; set; }
        public string Code { get; set; }
        public string HelpText { get; set; }
        public string EditorType { get; set; }
        public bool? IsMandatory { get; set; }
        public int Priority { get; set; }
        public bool IsDisabled { get; set; } = false;
        public string OnChange { get; set; }
        public AttributeDataSource DataSource { get; set; }

    }
}
