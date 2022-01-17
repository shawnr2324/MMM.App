using MMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class FinancialEntityData : IFinancialEntityData
    {
        public ISqlDataAccess _db { get; }

        public FinancialEntityData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<FinancialEntity_Model>> GetAllUserFinancialEntities(string userID)
        {
            string sql = @"select   fe.Id, 
                                    fe.UserID,
                                    fe.EntityTypeID, 
                                    fe.Balance, 
                                    fe.InterestRate, 
                                    fe.OpenDate, 
                                    fe.MinimumPayment, 
                                    fe.APY, 
                                    fe.EntityName, 
                                    fe.InitialAmount, 
                                    fet.EntityType 
                            from dbo.Financial_Entity fe 
                                left outer join Financial_Entity_Type fet on fe.EntityTypeID = fet.Id 
                            where fe.UserID = @userID";

            return _db.LoadData<FinancialEntity_Model, dynamic>(sql, new { UserID = userID });
        }

        public Task<FinancialEntity_Model> GetFinancialEntity(int id)
        {
            string sql = @"select   fe.Id, 
                                    fe.UserID,
                                    fe.EntityTypeID, 
                                    fe.Balance, 
                                    fe.InterestRate, 
                                    fe.OpenDate, 
                                    fe.MinimumPayment, 
                                    fe.APY, 
                                    fe.EntityName, 
                                    fe.InitialAmount, 
                                    fet.EntityType 
                            from dbo.Financial_Entity fe 
                                left outer join Financial_Entity_Type fet on fe.EntityTypeID = fet.Id 
                            where fe.Id = @id";
            
            return _db.LoadDataObject<FinancialEntity_Model, dynamic>(sql, new { Id = id });
        }

        public Task UpdateFinancialEntity(FinancialEntity_Form_Model financialEntity)
        {
            string sql = @"UPDATE dbo.Financial_Entity 
                            SET EntityTypeID = @EntityTypeID,
                                UserID = @UserID,
                                Balance = @Balance,
                                InterestRate = @InterestRate,
                                OpenDate = @OpenDate,
                                MinimumPayment = @MinimumPayment,
                                APY = @APY,
                                EntityName = @EntityName,
                                InitialAmount = @InitialAmount
                            WHERE Id = @Id";

            return _db.SaveData(sql, financialEntity);
        }

        public Task InsertFinancialEntity(FinancialEntity_Form_Model financialEntity)
        {
            string sql = @"insert into dbo.Financial_Entity (EntityTypeID, UserID, Balance, InterestRate, OpenDate, MinimumPayment, APY, EntityName, InitialAmount)
                            values (@EntityTypeID, @UserID, @Balance, @InterestRate, @OpenDate, @MinimumPayment, @APY, @EntityName, @InitialAmount);";

            return _db.SaveData(sql, financialEntity);
        }
    }
}
