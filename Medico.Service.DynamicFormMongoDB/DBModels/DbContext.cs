using Medico.Service.DynamicFormMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.DBModels
{
    public class DbContext
    {
        private readonly IMongoDatabase _database = null;

        public DbContext(IOptions<Settings> setting)
        {
            try
            {
                MongoClientSettings mongoSettings = MongoClientSettings.FromUrl(new MongoUrl(setting.Value.ConnectionString));

                if (setting.Value.IsSSL)
                    mongoSettings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };

                var client = new MongoClient(mongoSettings);
                if (client != null)
                    _database = client.GetDatabase(setting.Value.Database);
            }catch (Exception e)
            {
                throw new Exception("Can not connect to db server", e);
            }
            
        }

        public IMongoCollection<FormPatient> FormPatient => _database.GetCollection<FormPatient>("FormPatient");
        /*
        public IMongoCollection<FormPatient> FormPatient
        {
            get
            {
                return _database.GetCollection<FormPatient>("FormPatient");
            }
        }
        */
    }
}
