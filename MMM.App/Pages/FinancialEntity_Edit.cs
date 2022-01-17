using Microsoft.AspNetCore.Components;
using DataAccessLibrary;
using MMM.Models;
using Microsoft.JSInterop;

namespace MMM.App.Pages
{
    public partial class FinancialEntity_Edit
    {
        [Inject]
        private IJSRuntime JsRuntime { get; set; }
        [Inject]
        private IEntityTypeData _db_EntityTypeDb { get; set; }
        [Inject]
        private IFinancialEntityData _db_FinancialEntityDb { get; set; }
        [Parameter]
        public string Id { get; set; }
        private FinancialEntity_Model financialEntity = new FinancialEntity_Model();
        private FinancialEntity_Form_Model financialEntity_Form = new FinancialEntity_Form_Model();
        private List<EntityType_Model> entityTypes;

        protected override async Task OnInitializedAsync()
        {
            financialEntity = await _db_FinancialEntityDb.GetFinancialEntity(Int32.Parse(Id));
            entityTypes = await _db_EntityTypeDb.GetEntityTypes();

            financialEntity_Form.Id = financialEntity.Id;
            financialEntity_Form.EntityTypeID = financialEntity.EntityTypeID;
            financialEntity_Form.UserID = financialEntity.UserID;
            financialEntity_Form.Balance = financialEntity.Balance;
            financialEntity_Form.InterestRate = financialEntity.InterestRate;
            financialEntity_Form.OpenDate = financialEntity.OpenDate;
            financialEntity_Form.MinimumPayment = financialEntity.MinimumPayment;
            financialEntity_Form.APY = financialEntity.APY;
            financialEntity_Form.EntityName = financialEntity.EntityName;
            financialEntity_Form.InitialAmount = financialEntity.InitialAmount;
        }

        private async Task UpdateFinancialEntity()
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

            await _db_FinancialEntityDb.UpdateFinancialEntity(financialEntity_Form);

            financialEntity = new FinancialEntity_Model();
            financialEntity = await _db_FinancialEntityDb.GetFinancialEntity(Int32.Parse(Id));

            financialEntity_Form = new FinancialEntity_Form_Model();
            financialEntity_Form.Id = financialEntity.Id;
            financialEntity_Form.EntityTypeID = financialEntity.EntityTypeID;
            financialEntity_Form.UserID = financialEntity.UserID;
            financialEntity_Form.Balance = financialEntity.Balance;
            financialEntity_Form.InterestRate = financialEntity.InterestRate;
            financialEntity_Form.OpenDate = financialEntity.OpenDate;
            financialEntity_Form.MinimumPayment = financialEntity.MinimumPayment;
            financialEntity_Form.APY = financialEntity.APY;
            financialEntity_Form.EntityName = financialEntity.EntityName;
            financialEntity_Form.InitialAmount = financialEntity.InitialAmount;
        }

        private void HandleValidSubmit()
        {

            JsRuntime.InvokeAsync<string>("console.log", "Valid Submit Handled");
            JsRuntime.InvokeAsync<string>("console.log", financialEntity_Form.SavingsAndDebt);
        }

        private void HandleInvalidSubmit()
        {
            JsRuntime.InvokeAsync<string>("console.log", "Invalid");
        }

    }
}
