using DemoCore.BLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Helper
{
   public static class MailSender
    {

        public static string SendMail(MailVM mail)
        {
            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;

                    smtp.Credentials = new NetworkCredential("lajjayousef66@gmail.com", "01201394400omeryousef");
                
                   // smtp.Send("lajjayousef66@gmail.com", "ahmedousefy62@gmail.com", mail.Title, mail.Message);
                    smtp.Send("lajjayousef66@gmail.com", "raaedserag@gmail.com", mail.Title, mail.Message);
                }
                

                return "Done ! Mail Sent Successfully";

               


            }
            catch (Exception )
            {
            
                return "Failed To Send E-Mail";
            }
        }
    }
}
