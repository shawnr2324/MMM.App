using MMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class EntityTypeData : IEntityTypeData
    {
        public ISqlDataAccess _db { get; }
        public EntityTypeData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<EntityType_Model>> GetEntityTypes()
        {
            string sql = "select * from dbo.Financial_Entity_Type";

            return _db.LoadData<EntityType_Model, dynamic>(sql, new { });
        }

        public Task InsertEntityType(EntityType_Model entityType)
        {
            string sql = @"insert into dbo.Financial_Entity_Type (EntityType)
                            values (@EntityType);";

            return _db.SaveData(sql, entityType);
        }
    }
}
