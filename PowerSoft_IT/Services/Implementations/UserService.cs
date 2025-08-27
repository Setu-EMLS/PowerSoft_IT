using PowerSoft_IT.Models;
using PowerSoft_IT.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PowerSoft_IT.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public User GetUserByEmail(string email)
        {
            // Retrieve user by email
            return _context.Tbl_Users.FirstOrDefault(u => u.Email == email);
        }

        public bool VerifyPassword(string enteredPassword, string storedPassword, string salt)
        {
            // Implement your password hashing logic here
            var hashedPassword = CreatePasswordHash(enteredPassword, salt);
            return hashedPassword == storedPassword;
        }

        public string CreateSaltKey(int size)
        {
            // Generate a cryptographic random number
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        public string CreatePasswordHash(string password, string salt, string passwordFormat = "SHA1")
        {
            if (String.IsNullOrEmpty(passwordFormat))
                passwordFormat = "SHA1";
            string saltAndPassword = String.Concat(password, salt);
            //return FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPassword, passwordFormat);
            var algorithm = HashAlgorithm.Create(passwordFormat);
            if (algorithm == null)
                throw new ArgumentException("Unrecognized hash name");
            var hashByteArray = algorithm.ComputeHash(Encoding.UTF8.GetBytes(saltAndPassword));
            return BitConverter.ToString(hashByteArray).Replace("-", "");
        }

        public bool ChangePassword(string email, string currentPassword, string newPassword)
        {
            var user = GetUserByEmail(email);
            if (user == null)
                return false;

            // Verify current password
            if (!VerifyPassword(currentPassword, user.Password, user.Salt))
                return false;

            // Create new salt and hash
            var newSalt = CreateSaltKey(5); // You can increase size for more security
            var newHashedPassword = CreatePasswordHash(newPassword, newSalt);

            // Update password and salt
            user.Password = newHashedPassword;
            user.Salt = newSalt;

            _context.Tbl_Users.Update(user);
            _context.SaveChanges();

            return true;
        }
    }
}