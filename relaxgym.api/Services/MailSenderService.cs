using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace relaxgym.api.Services
{
    public class MailSenderService : IMailSenderService
    {
        private readonly IConfiguration _configuration;
        public MailSenderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private MailjetClient GetMailjetClient()
        {
            return new MailjetClient(_configuration["MailJet:ApiKey"], _configuration["MailJet:SecretKey"]);
        }

        public async Task<bool> SendEmailAsync(string toEmail, string nombreUsuario, string idWebSolicitud)
        {
            MailjetClient client = GetMailjetClient();

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource
            }
            .Property(Send.Messages, new JArray {
                new JObject {
                    {
                        "FromEmail", _configuration["MailJet:EmailSender"]
                    },
                    {
                        "FromName", _configuration["MailJet:NameSender"]
                    },
                    {
                        "To", toEmail
                    },
                    {
                        "Mj-TemplateID", _configuration["MailJet:TemplateId"]
                    },
                    {
                        "Mj-TemplateLanguage", true
                    },
                    {
                        "Vars",
                        new JObject {
                            {
                                "nombreUsuario", nombreUsuario
                            },
                            {
                                "urlRestablecimiento", string.Concat(_configuration["FrontEnd:UrlResetPassword"],idWebSolicitud)
                            }
                        }
                    }
                }
            });

            MailjetResponse response = await client.PostAsync(request);


            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
