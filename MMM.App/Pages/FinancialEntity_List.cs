using Microsoft.AspNetCore.Components;
using DataAccessLibrary;
using MMM.Models;
using Microsoft.JSInterop;
using MMM.App.Shared.Data;

namespace MMM.App.Pages
{
    public partial class FinancialEntity_List
    {
        [Inject]
        private IJSRuntime JsRuntime { get; set; }
        [Inject]
        private NavigationManager _uriHelper { get; set; }
        [Inject]
        private IFinancialEntityData _db_FinancialEntityDb { get; set; }
        [Inject]
        private IAuthUserData _authUserData { get; set; }
        private List<FinancialEntity_Model> financialEntities_list;
        private AuthUser_Model authUser = new AuthUser_Model();
        //public FinancialEntity_Model specificEntity { get; set; }

        protected override async Task OnInitializedAsync()
        {
            authUser = await _authUserData.GetAuthUserData();
            financialEntities_list = await _db_FinancialEntityDb.GetAllUserFinancialEntities(authUser.Id);
        }

        private void Navigate_CreateFinancialEntity()
        {
            _uriHelper.NavigateTo("financialentity_create");
        }

        private async void FinancialEntity_View(int id)
        {
            JsRuntime.InvokeAsync<string>("console.log", id);
            _uriHelper.NavigateTo($"financialentity_detail/{id}");
        }

        private void FinancialEntity_Edit(int id)
        {
            _uriHelper.NavigateTo($"financialentity_edit/{id}");
        }

        private void FinancialEntity_Transaction(int id)
        {
            _uriHelper.NavigateTo($"financialentity_transaction/{id}");
        }
    }
}
