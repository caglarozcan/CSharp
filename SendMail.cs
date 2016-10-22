using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Codes
{
	public class Mail
	{
    public void SendMail(string mailAddr, string subject, string path, Dictionary<string, string> replacements)
		{
			MailMessage mail = new MailMessage();
			mail.From = new MailAddress("Gönderici mail adresi");
			mail.To.Add(mailAddr);
			mail.Subject = subject;
			mail.IsBodyHtml = true;

			using (System.IO.StreamReader streamReader = new System.IO.StreamReader(path, Encoding.GetEncoding("UTF-8"))) // mesaj formu
			{
				mail.Body = streamReader.ReadToEnd();
			}

			foreach (var key in replacements)
			{
				mail.Body = mail.Body.Replace(key.Key, key.Value);
			}

			SmtpClient sc = new SmtpClient();
			sc.Port = 587;
			sc.Host = "smtp.gmail.com";
			sc.EnableSsl = true;
			sc.Credentials = new NetworkCredential("Gmail Adresi", "Gmail Şifre");
			sc.Send(mail);
		}
	}
}
