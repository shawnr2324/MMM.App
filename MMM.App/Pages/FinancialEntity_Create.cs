using MMM.Models;
using DataAccessLibrary;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MMM.App.Shared.Data;

namespace MMM.App.Pages
{
    public partial class FinancialEntity_Create
    {
        [Inject]
        private IJSRuntime JsRuntime { get; set; }
        [Inject]
        private IEntityTypeData _db_EntityTypeDb { get; set; }
        [Inject]
        private IFinancialEntityData _db_FinancialEntityDb { get; set; }
        [Inject]
        private IAuthUserData _authUserData { get; set; }
        private FinancialEntity_Form_Model financialEntity = new FinancialEntity_Form_Model();
        private List<EntityType_Model> entityTypes;
        private AuthUser_Model authUser;

        protected override async Task OnInitializedAsync()
        {
            authUser = await _authUserData.GetAuthUserData();
            financialEntity.UserID = authUser.Id;
            entityTypes = await _db_EntityTypeDb.GetEntityTypes();
        }

        private async Task InsertFinancialEntity()
        {
            HandleValidSubmit();

            if (financialEntity.InterestRate != null)
            {
                financialEntity.InterestRate = financialEntity.InterestRate / 100;
            }

            if (financialEntity.APY != null)
            {
                financialEntity.APY = financialEntity.APY / 100;
            }
            
            await _db_FinancialEntityDb.InsertFinancialEntity(financialEntity);
            financialEntity = new FinancialEntity_Form_Model();
            financialEntity.UserID = authUser.Id;
        }

        private void HandleValidSubmit()
        {
            
            JsRuntime.InvokeAsync<string>("console.log", "Valid Submit Handled");
            //JsRuntime.InvokeAsync<string>("console.log", financialEntity.SavingsAndDebt);
        }

        private void HandleInvalidSubmit()
        {
            JsRuntime.InvokeAsync<string>("console.log", "Invalid");
        }
    }
}
