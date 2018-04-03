using System.Threading.Tasks;

namespace BatucaZL.Site.Services
{
    public interface IEmailService
    {
        Task EnviarEmail(string nome, string email, string assunto, string mensagem);
    }
}
