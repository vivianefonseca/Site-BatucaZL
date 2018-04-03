using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Text;
using System.Threading.Tasks;

namespace BatucaZL.Site.Services
{
    public class EmailService : IEmailService
    {

        public EmailService()
        {
        }

        public async Task EnviarEmail(string nome, string email, string assunto, string mensagem)
        {
            try
            {
                //var path = $"{_env.ContentRootPath}\\EmailTemplates\\{template}";
                //var body = File.ReadAllText(path);

                //var key = _config["MailService:ApiKey"];

                var client = new SendGridClient("");
                StringBuilder corpo = new StringBuilder();
                corpo.Append("Nome: {0} <br/>");
                corpo.Append("E-mail: {1} <br/>");
                corpo.Append("Assunto: {2} <br/>");
                corpo.Append("Mensagem: {3}");
                
                var mensagemFormatada = string.Format(corpo.ToString(), nome, email, assunto, mensagem);

                var mailMsg = MailHelper.CreateSingleEmail(
                  new EmailAddress("viviane.dsfonseca@gmail.com"),
                  new EmailAddress("viviane.dsfonseca@gmail.com"),
                  $"E-mail ",
                  mensagemFormatada,
                  mensagemFormatada);

                var response = await client.SendEmailAsync(mailMsg);

                if (response.StatusCode >= System.Net.HttpStatusCode.PartialContent) // Not 200 or 202
                {
                    var result = await response.Body.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
