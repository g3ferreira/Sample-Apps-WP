using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace _8pos.Controllers.Utilities
{
    public  class EmailController
    {
        private SmtpClient smtpClient = new SmtpClient();
        private MailMessage mailMessage = new MailMessage();
        private string emailBody = string.Empty;
        public  void smtpClientConfig()
        {
            smtpClient.Host = "outlook.office365.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("genilson.ferreira@transire.com.br", "G3transire");
        }

        public  void sendMail(string to, string cc, string cco, string subject, string body)
        {
            smtpClientConfig();
            mailMessage.From = new System.Net.Mail.MailAddress("genilson.ferreira@transire.com.br");

            if (!string.IsNullOrWhiteSpace(to))
            {
                mailMessage.To.Add(new System.Net.Mail.MailAddress(to));
            }
            else
            {
                //MessageBox.Show("Campo 'para' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*if (!string.IsNullOrWhiteSpace(cc))
                mailMessage.CC.Add(new System.Net.Mail.MailAddress(cc));
            if (!string.IsNullOrWhiteSpace(cco))
                mailMessage.Bcc.Add(new System.Net.Mail.MailAddress(cco));*/
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception er)
            {
                string a = er.InnerException.Message;
            }

        }


        public  string getEmailBody(string link)
        {
            emailBody = string.Format(@"
                                        <div style=""width: 100%; font-family: 'Arial', sans-serif; text-align: center;/"">
                                          <div style=""width: 100%; height: 150px; background-color: #6c6c6c"">
                                            <img style=""padding: 50px;"" src='http://www.8pos.net/img/logo_8pos_big.png'>
                                          </div>
                                          <h1 style=""margin: 50px 0px;"">Thank you for register!</h1>
                                          <h5>Please, click at the button below to validate your account.</h5>
                                          <a href= ""{0}"" style='margin-bottom: 40px; background-color:#EB7035;border:1px solid #EB7035;border-radius: 2px;color:#ffffff;display:inline-block;font-family:sans-serif;font-size:16px;line-height:44px;text-align:center;text-decoration:none;width:150px;-webkit-text-size-adjust:none;mso-hide:all;'>CONFIRM</a>
                                          <hr>
                                          <h5>If you have not registered, please ignore this email.</h5>
                                        </div>", link);
            return emailBody;
        }
    }
}