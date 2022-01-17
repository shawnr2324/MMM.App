using MMM.Models;

namespace DataAccessLibrary
{
    public interface IFinancialEntityData
    {
        ISqlDataAccess _db { get; }

        Task<List<FinancialEntity_Model>> GetAllUserFinancialEntities(string userID);
        Task<FinancialEntity_Model> GetFinancialEntity(int financialEntityID);
        Task UpdateFinancialEntity(FinancialEntity_Form_Model financialEntity);
        Task InsertFinancialEntity(FinancialEntity_Form_Model financialEntity);
    }
}