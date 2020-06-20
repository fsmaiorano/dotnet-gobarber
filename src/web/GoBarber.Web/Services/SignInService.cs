using GoBarber.Web.Helpers;
using GoBarber.Web.Models;
using GoBarber.Web.Models.SignIn;
using GoBarber.Web.Models.User;
using System.Threading.Tasks;

namespace GoBarber.Web.services
{
    public class SignInService
    {
        public static async Task<AuthenticationModelResult> DoLogin(AuthenticationModelInput input)
        {
            return (AuthenticationModelResult)await HttpHelper.HttpPostAsync<AuthenticationModelResult>(ApiConstants.SignInUrl, input);
        }
    }
}