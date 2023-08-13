using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace HackathonEventCode.Pages
{
    
    public class RegistrationModel : PageModel
    {
        public bool data = false;
        public string firstName = "";
        public string lastName = "";
        public string phoneNumber = "";
        public string Email = "";
        public string complaintType = "";
        public string content = "";
        public string address = "";
        public string emailId = "";
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            data = true;
            firstName = Request.Form["fname"];
            lastName = Request.Form["lname"];
            phoneNumber = Request.Form["phone_number"];
            Email = Request.Form["Email_id"];
            complaintType = Request.Form["type"];
            content = Request.Form["content"];
            address = Request.Form["address"];

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("a.sridhar51@gmail.com");
            mailMessage.To.Add(complaintType);
            mailMessage.Subject = "Subject";
            mailMessage.Body =
                "Name: " + firstName + lastName +
                "Phone number: " + phoneNumber +
                "Email: " + Email +
                "Address: " + address +
                content;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("a.sridhar51@gmail.com", "mpuekjxyrduzjnsi");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
    }
}
