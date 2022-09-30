using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStore.Models.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
    }
}