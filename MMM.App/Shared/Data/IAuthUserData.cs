using MMM.Models;

namespace MMM.App.Shared.Data
{
    public interface IAuthUserData
    {
        AuthUser_Model authUser { get; set; }

        Task<AuthUser_Model> GetAuthUserData();
    }
}