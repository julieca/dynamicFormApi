using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.Models
{
    public enum DataSourceType
    {
        Array,
        Mvc,
        OData,
        RemoteController,
        StaticJson
    }
}
