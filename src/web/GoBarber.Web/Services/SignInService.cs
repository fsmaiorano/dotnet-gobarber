using GoBarber.Web.Helpers;
using GoBarber.Web.Models.SignIn;
using System.Threading.Tasks;
using static GoBarber.DTO.Authentication.AuthenticationDTO;

namespace GoBarber.Web.services
{
    public class SignInService
    {
        public static async Task<AuthenticationResult> DoLogin(AuthenticationModel input)
        {
            return (AuthenticationResult)await HttpHelper.HttpPostAsync<AuthenticationResult>(ApiConstants.SignInUrl, input);
        }
    }
}