using Core.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Model;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.MailManager
{
    public class MailManager : IMailManager
    {
        private readonly IHostEnvironment env;
 
        private readonly IOptions<ApplicationSettings> settings;

        public MailManager(
            IHostEnvironment env,
          
            IOptions<ApplicationSettings> settings
            )
        {
            this.env = env;
         
            this.settings = settings;
        }

        public string ReadFileContent(string FileName)
        {

            using (StreamReader reader = File.OpenText("./wwwroot/Mailing/" + FileName))
            {
                string fileContent = reader.ReadToEnd();
                if (fileContent != null && fileContent != "")
                {
                    return fileContent;
                }
            }

            return "";
        }

        /// <summary>
        /// </summary>
        /// <param name="Subject"></param>
        /// <param name="FromName"></param>
        /// <param name="FileName"></param>
        /// <param name="Recipients"></param>
        /// <returns></returns>
        public string Send(string Subject, string FromName, string FileName, Dictionary<string, dynamic> Recipients, dynamic ExtraData = null)
        {
            string MailContent = ReadFileContent(FileName);
            string HeaderContent = ReadFileContent("header.html");
            string FooterContent = ReadFileContent("footer.html");

            MailContent = MailContent.Replace("#header#", HeaderContent);
            MailContent = MailContent.Replace("#footer#", FooterContent);

            RestClient client = new RestClient();
            client.BaseUrl = new Uri(settings.Value.MailgunAPISettings.BaseURL);
            client.Authenticator = new HttpBasicAuthenticator(settings.Value.MailgunAPISettings.AuthenticatorType, settings.Value.MailgunAPISettings.APIKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", settings.Value.MailgunAPISettings.Domain, ParameterType.UrlSegment);
            request.Resource = settings.Value.MailgunAPISettings.Resource;
            request.AddParameter("from", (!string.IsNullOrWhiteSpace(FromName) ? FromName : "Sportue") + " <" + settings.Value.MailgunAPISettings.FromMail + ">");
            request.AddParameter("subject", Subject);
            request.AddParameter("html", MailContent);
            request.AddParameter("recipient-variables", Recipients.ToJson());

            foreach (var item in Recipients)
                request.AddParameter("to", item.Key);

            request.Method = Method.POST;
            IRestResponse response = client.Execute(request);
            // client.PostAsync(request, null);



            return "";
        }
    }
}
