using MMM.Models;

namespace DataAccessLibrary
{
    public interface IEntityTypeData
    {
        ISqlDataAccess _db { get; }

        Task<List<EntityType_Model>> GetEntityTypes();
        Task InsertEntityType(EntityType_Model entityType);
    }
}