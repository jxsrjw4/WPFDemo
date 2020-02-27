using System.Threading.Tasks;

namespace WPFDemo.Infrastructure.ServerInteraction
{
    public interface IAuthApi
    {
        LoginResponse LoginIn(LoginArgs args);

        void SignOutAsync(long id);
    }
}
