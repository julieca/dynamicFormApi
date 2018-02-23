using Medico.Service.DynamicFormMongoDB.DBModels;
using Medico.Service.DynamicFormMongoDB.Interfaces;
using Medico.Service.DynamicFormMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.Repository
{
    public class FormPatientRepository : IRepository<FormPatient>
    {
        private readonly DbContext _context = null;
        private readonly FilterDefinition<FormPatient> isDeleteFilter = Builders<FormPatient>.Filter.Eq("IsDeleted", 0);

        //var filter = Builders<Student>.Filter.Lt(student => student.Age, 25);

        public FormPatientRepository(IOptions<Settings> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<FormPatient> Add(FormPatient item)
        {
            try
            {
                item.EditBy = item.AddBy;
                await _context.FormPatient.InsertOneAsync(item);
                return item;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<FormPatient> Delete(string id)
        {
            try
            {
                var data = this.GetById(id).Result;
                data.IsDeleted = 1;
                await _context.FormPatient.ReplaceOneAsync(x => x.Id.Equals(id) && x.IsDeleted == 0, data);
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<FormPatient>> Get()
        {
            try
            {
                return await _context.FormPatient.Find(isDeleteFilter).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<FormPatient> GetById(string id)
        {
            var idFilter = Builders<FormPatient>.Filter.Eq("Id", id);
            var filter = isDeleteFilter & idFilter;
            try
            {
                return await _context.FormPatient.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Tuple<FormPatient, FormPatient>> Update(string id, FormPatient item)
        {
            try
            {
                var oldData = this.GetById(id).Result;
                await _context.FormPatient.ReplaceOneAsync(x => x.Id.Equals(id) && x.IsDeleted == 0, item);
                return new Tuple<FormPatient, FormPatient>(oldData, item);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
