using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ApplicationSettings
    {
        public ApplicationSettings()
        {
            MailgunAPISettings = new MailgunAPISettings();
            FacebookAPI = new FacebookSettings();
        }

        public MailgunAPISettings MailgunAPISettings { get; set; }
        public FacebookSettings FacebookAPI { get; set; }
    }

    public class MailgunAPISettings
    {
        public string BaseURL { get; set; }
        public string AuthenticatorType { get; set; }
        public string APIKey { get; set; }
        public string Resource { get; set; }
        public string Domain { get; set; }
        public string FromMail { get; set; }
    }

    public class FacebookSettings
    {
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
    }
}
