using PowerSoft_IT.Models;

namespace PowerSoft_IT.Services.Interfaces
{
    public interface IIdentityService
    {
        Task signInUser(User user);
    }
}
