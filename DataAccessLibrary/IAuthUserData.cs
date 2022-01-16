using MMM.Models;

namespace DataAccessLibrary
{
    public interface IAuthUserData
    {
        AuthUser_Model authUser { get; set; }

        Task<AuthUser_Model> GetAuthUserData();
    }
}