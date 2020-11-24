using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.MailManager
{
    public interface IMailManager
    {
        string ReadFileContent(string FileName);
        string Send(string Subject, string FromName, string FileName, Dictionary<string, dynamic> Recipients, dynamic ExtraData);
    }
}
