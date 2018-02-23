using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.Models
{
    public class Form
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public Guid TenantId { get; set; }

        [Required]
        public Guid SiteId { get; set; }

        public string Name { get; set; }
        public string Template { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;

        [Required]
        public Guid AddBy { get; set; }

        public DateTime? EditDate { get; set; } = DateTime.Now;
        public Guid? EditBy { get; set; } = null;
        public int? IsDeleted { get; set; } = 0;
        public int? IsActive { get; set; } = 0;
    }
}
