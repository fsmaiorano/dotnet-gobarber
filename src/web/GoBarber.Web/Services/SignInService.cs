using GoBarber.DTO.Authentication;
using GoBarber.Web.Helpers;
using System.Threading.Tasks;

namespace GoBarber.Web.services
{
    public class SignInService
    {
        public static async Task<AuthenticationResult> DoLogin(AuthenticationInput input)
        {
            return (AuthenticationResult)await HttpHelper.HttpPostAsync<AuthenticationResult>(ApiConstants.SignInUrl, input);
        }
    }
}