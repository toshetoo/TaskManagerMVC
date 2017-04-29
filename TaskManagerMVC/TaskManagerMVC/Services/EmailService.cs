using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.Services
{
    public static class EmailService
    {
        public static void SendRegistrationEmail(User u)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("no-reply@management.com");
            mail.Subject = "Registration successfull";
            mail.To.Add(u.Email);
            mail.Body = "Hello " + u.FirstName + Environment.NewLine
                + "Thank you for registering. Confirm your registration by visiting the following link: "
                + Environment.NewLine
                + "http://localhost:" + HttpContext.Current.Request.Url.Port + "/Accounts/Verify?guid=" + u.Password;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            #region Private
            smtp.Credentials = new System.Net.NetworkCredential("testforhallmanager@gmail.com", "hallmanager");
            #endregion

            smtp.Send(mail);
        }
    }
}