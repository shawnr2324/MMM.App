using Microsoft.AspNetCore.Components;
using DataAccessLibrary;
using MMM.Models;
using Microsoft.JSInterop;

namespace MMM.App.Pages
{
    public partial class FinancialEntity_Trans
    {
        [Parameter]
        public string Id { get; set; }
    }
}
