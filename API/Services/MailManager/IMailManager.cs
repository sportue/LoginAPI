using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.MailManager
{
    public interface IMailManager
    {
        string ReadFileContent(string FileName);
        string Send(string Subject, string To, string FileName, Dictionary<string, string> Recipients, dynamic ExtraData);
        void SendSmpt(string subject, string body, string mail);
    }
}
