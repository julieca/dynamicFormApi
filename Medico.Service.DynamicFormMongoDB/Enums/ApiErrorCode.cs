using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.Enums
{
    public class ApiErrorCode
    {
        public static string INVALID_PARAMETER = "INVALID_PARAMETER";
        public static string DATA_NOT_FOUND = "DATA_NOT_FOUND";
        public static string ERROR_ADD = "ERROR_ADD";
        public static string ERROR_UPDATE = "ERROR_UPDATE";
        public static string ERROR_EDIT = "ERROR_EDIT";
        public static string ERROR_PATCH = "ERROR_PATCH";
        public static string ERROR_DELETE = "ERROR_DELETE";
    }
}
