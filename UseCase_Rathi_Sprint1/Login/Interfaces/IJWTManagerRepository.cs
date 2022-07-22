using Login.ViewModel;

namespace Login.Interfaces
{
    public interface IJWTManagerRepository
    {

        /// <summary>Authenticates the specified users.</summary>
        /// <param name="users">The Logged user details</param>
        /// <param name="isRegister">True if it is registration mode else false</param>
        /// <returns>The Generated token</returns>
        Tokens Authenticate(LoginViewModel users, bool isRegister);
    }
}
