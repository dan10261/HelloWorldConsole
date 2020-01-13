using System;
using System.Net.Mail;

namespace ConsoleAppHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = "smtp.gmail.com";
            string to = "TEST@gmail.com";
            string from = "TEST@gmail.com";
            using (MailMessage message = new MailMessage(from, to))
            {
                message.Subject = "Using the new SMTP client.";
                message.Body = @"Using this new feature, you can send an email message from an application very easily.";
                using (SmtpClient client = new SmtpClient(server, 587))
                {
                    //Turn on the Access for less secure apps:https://myaccount.google.com/lesssecureapps
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("TEST@gmail.com", "password");

                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                            ex.ToString());
                    }
                }
            }
        }
    }
}
