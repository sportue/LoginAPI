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
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
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
        public string Send(string Subject, string To, string FileName, Dictionary<string, string> Recipients, dynamic ExtraData = null)
        {
            string MailContent = ReadFileContent(FileName);

            var fromAdress = new MailAddress("cihan.oguz@windowslive.com");
            var ToAdress = new MailAddress(To);



            MailContent = MailContent.Replace("%recipient.FullName%", Recipients["recipient.FullName"]);
            foreach (var item in Recipients)
            {
                MailContent = MailContent.Replace("%" + item.Key + "%", item.Value);
            }


            using (var smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.live.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAdress.Address, "This is your passowrd")
            })
            {
                using (var message = new MailMessage(fromAdress, ToAdress) { Subject = Subject, Body = MailContent, IsBodyHtml = true })
                {
                    smtp.Send(message);
                }
            }

            return "";

        }

        public void SendSmpt(string subject, string body, string mail)
        {
            var fromAdress = new MailAddress("cihan.oguz@windowslive.com");
            var toAdress = new MailAddress(mail);

            string MailContent = ReadFileContent("forgot-password.html");
            MailContent = MailContent.Replace("%recipient.FullName%", "cihan");
            // string HeaderContent = ReadFileContent("header.html");
            // string FooterContent = ReadFileContent("footer.html");

            // MailContent = MailContent.Replace("#header#", HeaderContent);
            // MailContent = MailContent.Replace("#footer#", FooterContent);

            using (var smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.live.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAdress.Address, "This is your passowrd")
            })
            {
                using (var message = new MailMessage(fromAdress, toAdress) { Subject = subject, Body = MailContent, IsBodyHtml = true })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}
