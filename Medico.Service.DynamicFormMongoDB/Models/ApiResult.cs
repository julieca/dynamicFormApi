using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.Models
{
    public class ApiResult
    {
        public bool Status { get; set; } = false;
        public string Code { get; set; } = null;
        public string Messages { get; set; } = null;
        public object Payload { get; set; } = null;
    }
}
