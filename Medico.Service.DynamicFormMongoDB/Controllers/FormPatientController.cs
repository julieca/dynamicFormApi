using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Medico.Service.DynamicFormMongoDB.DBModels;
using Microsoft.Extensions.Options;
using Medico.Service.DynamicFormMongoDB.Models;
using Medico.Service.DynamicFormMongoDB.Interfaces;
using Newtonsoft.Json;
using Medico.Service.DynamicFormMongoDB.Enums;

namespace Medico.Service.DynamicFormMongoDB.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FormPatientController : Controller
    {
        private readonly IRepository<FormPatient> _repo;
        public FormPatientController(IRepository<FormPatient> repo)
        {
            _repo = repo;
        }
        // GET: api/FormPatient
        [HttpGet]
        public async Task<JsonResult> Get(Guid? tenantId, Guid? siteId, 
            int? isActive, Guid? patientId, string templateId = null, string processType = null)
        {
            ApiResult result = new ApiResult();

            var _payload = await _repo.Get();

            if (tenantId.HasValue)
            {
                _payload = _payload.Where(x => x.TenantId == tenantId);
            }
            if (siteId.HasValue)
            {
                _payload = _payload.Where(x => x.SiteId == siteId);
            }
            if (!string.IsNullOrEmpty(templateId))
            {
                _payload = _payload.Where(x => x.TemplateId.ToString() == templateId);
            }
            if (patientId.HasValue)
            {
                _payload = _payload.Where(x => x.PatientId == patientId);
            }
            if (!string.IsNullOrEmpty(processType))
            {
                _payload = _payload.Where(x => x.ProcessType.ToLower() == processType.ToLower());
            }
            if (isActive.HasValue)
            {
                _payload = _payload.Where(x => x.IsActive == isActive);
            }
            if(_payload.Count() > 0)
            {
                _payload = _payload.OrderByDescending(x => x.AddDate).ToList();
            }

            result.Status = true;
            result.Payload = _payload ?? new List<FormPatient>();
            return Json(result, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        // GET: api/FormPatient/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<JsonResult> Get(string id)
        {
            ApiResult result = new ApiResult();

            if(string.IsNullOrEmpty(id))
            {
                return Json(new ApiResult() { Status = false, Code = ApiErrorCode.INVALID_PARAMETER, Messages = "The parameter id cannot be null or empty.", Payload = null });
            }

            var _payload = await _repo.GetById(id);
            result.Status = true;
            if(_payload == null)
            {
                result.Code = ApiErrorCode.DATA_NOT_FOUND;
                result.Messages = "Data Not Found.";
            }
            else
            {
                result.Payload = _payload;
            }
            return Json(result, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
        
        // POST: api/FormPatient
        [HttpPost]
        public async Task<JsonResult> Post([FromBody]FormPatient item)
        {
            if (item.KeyValue.Count == 0)
            {
                return Json(new ApiResult() { Status = false, Code = ApiErrorCode.INVALID_PARAMETER, Messages = "The parameter KeyValue cannot be null or empty. " });
            }

            var _payload = await _repo.Add(item);
            ApiResult result = new ApiResult()
            {
                Status = true,
                Payload = _payload
            };
            
            return Json(result, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        // PUT: api/FormPatient/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Put(string id, [FromBody] FormPatient item)
        {

            if (string.IsNullOrEmpty(id))
            {
                return Json(new ApiResult() { Status = false, Code = ApiErrorCode.INVALID_PARAMETER, Messages = "The parameter id cannot be null or empty.", Payload = null });
            }

            if (item.KeyValue.Count == 0)
            {
                return Json(new ApiResult() { Status = false, Code = ApiErrorCode.INVALID_PARAMETER, Messages = "The parameter KeyValue cannot be null or empty. " });
            }
            var _payload = await _repo.Update(id, item);
            ApiResult result = new ApiResult()
            {
                Status = true,
                Payload = _payload
            };

            return Json(result, new JsonSerializerSettings() { Formatting = Formatting.Indented });

        }

        // DELETE: api/ApiWithActions/5
        [HttpPatch("{id}")]
        public async Task<JsonResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new ApiResult() { Status = false, Code = ApiErrorCode.INVALID_PARAMETER, Messages = "The parameter id cannot be null or empty.", Payload = null });
            }

            var _payload = await _repo.Delete(id);
            ApiResult result = new ApiResult()
            {
                Status = true,
                Payload = _payload
            };

            return Json(result, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
