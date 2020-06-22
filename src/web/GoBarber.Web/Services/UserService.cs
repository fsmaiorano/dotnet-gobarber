using GoBarber.DTO.Authentication;
using GoBarber.DTO.User;
using GoBarber.Web.Helpers;
using System.Threading.Tasks;

namespace GoBarber.Web.services
{
    public class UserService
    {
        public static async Task<AuthenticationResult> Authentication(AuthenticationInput input)
        {
            return (AuthenticationResult)await HttpHelper.HttpPostAsync<AuthenticationResult>(ApiConstants.SignInUrl, input);
        }

        public static async Task<UserResult> Register(UserInput input)
        {
            return (UserResult)await HttpHelper.HttpPostAsync<UserResult>(ApiConstants.SignUpUrl, input);
        }
    }
}