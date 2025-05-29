using PowerSoft_IT.Models;

namespace PowerSoft_IT.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserByEmail(string email);
        bool VerifyPassword(string enteredPassword, string storedPassword, string salt);
        string CreateSaltKey(int size);
        string CreatePasswordHash(string password, string salt, string passwordFormat = "SHA1");
        bool ChangePassword(string email, string currentPassword, string newPassword);

    }
}
