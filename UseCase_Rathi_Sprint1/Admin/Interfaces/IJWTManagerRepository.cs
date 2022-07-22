using Admin.ViewModel;

namespace Admin.Interfaces
{
    public interface IJWTManagerRepository
    {
        /// <summary>Authenticates the specified users.</summary>
        /// <param name="users">The Logged user details</param>
        /// <param name="isRegister">True if it is registration mode else false</param>
        /// <returns>The Generated token</returns>
        Tokens Authenticate(LoginViewModel users, bool isRegister);


        /// <summary>Refreshes the specified credentials.</summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns>Returns the Refreshed token</returns>
        Tokens Refresh(RefreshCredentials credentials);
    }
}
