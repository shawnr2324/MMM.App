using DataAccessLibrary;
using MMM.Models;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace MMM.App.Pages
{
    public partial class FinancialEntity_Detail
    {
        [Inject]
        private IJSRuntime JsRuntime { get; set; }
        [Inject]
        private NavigationManager _uriHelper { get; set; }
        [Inject]
        private IFinancialEntityData _db_FinancialEntityDb { get; set; }
        [Inject]
        private IAuthUserData _authUserData { get; set; }
        private AuthUser_Model authUser = new AuthUser_Model();
        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public FinancialEntity_Model financialEntity { get; set; }


        protected override async Task OnInitializedAsync()
        {
            financialEntity = await _db_FinancialEntityDb.GetFinancialEntity(Int32.Parse(Id));
        }

    }
}
