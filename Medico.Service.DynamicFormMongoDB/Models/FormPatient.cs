using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.Models
{
    public class FormPatient
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public Guid TenantId { get; set; }

        [Required]
        public Guid SiteId { get; set; }

        [Required]
        public string TemplateId { get; set; }

        public Guid PatientId { get; set; }

        public List<KeyValue> KeyValue { get; set; } = new List<KeyValue>();

        public string ProcessType { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;

        [Required]
        public Guid AddBy { get; set; }

        public DateTime? EditDate { get; set; } = DateTime.Now;
        public Guid? EditBy { get; set; } = null;
        public int? IsDeleted { get; set; } = 0;
        public int? IsActive { get; set; } = 0;
    }
}
