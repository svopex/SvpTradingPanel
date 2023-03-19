using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Utils
{
    public class Messager
    {
        private ErrorMessageToEnum errorMessageToEnum;

        public Messager(ErrorMessageToEnum errorMessageToEnum = ErrorMessageToEnum.none)
        {
            this.errorMessageToEnum = errorMessageToEnum;
        }

        public ErrorMessageToEnum GetErrorMessageToEnum(string s)
        {
            if (s.ToLower() == "all")
            {
                errorMessageToEnum = ErrorMessageToEnum.all;
            }
            else if (s.ToLower() == "e-mail")
            {
                errorMessageToEnum = ErrorMessageToEnum.email;
            }
            else if (s.ToLower() == "sms")
            {
                errorMessageToEnum = ErrorMessageToEnum.sms;
            }
            else
            {
                errorMessageToEnum = ErrorMessageToEnum.none;
            }
            return errorMessageToEnum;
        }

        public void SendMessage(string subject, string text, string strategyName)
        {
            if (errorMessageToEnum == ErrorMessageToEnum.all || errorMessageToEnum == ErrorMessageToEnum.email)
            {
                string subjectWorkEmail = subject + ", strategy name: " + strategyName + ".";
                string textWorkEmail = " Strategy name: " + strategyName + ".<br /><br />" + text;

                Send(subjectWorkEmail, textWorkEmail, "svopex@gmail.com");

                Logger.WriteLine("Send information to e-mail.");
            }
            if (errorMessageToEnum == ErrorMessageToEnum.all || errorMessageToEnum == ErrorMessageToEnum.sms)
            {
                string subjectWorkSms = subject + " - " + strategyName + ".";
                string textWorkSms = text.PadLeft(50);

                Send(subjectWorkSms, textWorkSms, "svopex@vodafonemail.cz");

                Logger.WriteLine("Send information to sms.");
            }
        }

        private void Send(string subject, string text, string emailAddress)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("svopex@gmail.com", "kdevqgavswpxmfzc");
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("svopex@gmail.com", "Server trader");
            mail.To.Add(emailAddress);
            mail.Subject = subject;
            mail.Body = text;
            mail.IsBodyHtml = true;
            smtpClient.Send(mail);
        }
    }
}
