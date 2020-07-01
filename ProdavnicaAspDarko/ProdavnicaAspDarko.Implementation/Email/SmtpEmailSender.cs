using ProdavnicaAspDarko.Application.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public void Send(SendEmailDto emailDto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("mrtheend98@gmail.com", "theend27198")
            };

            var message = new MailMessage("mrtheend98@gmail.com", emailDto.SendTo);
            message.Subject = emailDto.Subject;
            message.Body = emailDto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
