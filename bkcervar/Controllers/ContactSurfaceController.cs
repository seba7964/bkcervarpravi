using bkcervar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace bkcervar.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public ActionResult ShowForm()
        {
            ContactModel myModel = new ContactModel();
            return PartialView("ContactForm", myModel);
        }

        public ActionResult HandleFormPost(ContactModel model)
        {

            var newComment = Services.ContentService.CreateContent(model.Name + " - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), CurrentPage.Id, "contactFormula");
            newComment.SetValue("emailFrom", model.Email);
            newComment.SetValue("contactName", model.Name);
            newComment.SetValue("contactMessage", model.Message);
            Services.ContentService.SaveAndPublishWithStatus(newComment);
            LogHelper.Debug(typeof(ContactSurfaceController),"model" + model.Email +  "name" + model.Name + " message" + model.Message);

            MailMessage mail = new MailMessage();
            //var from = new MailAddress(Email.Text);
            mail.From = new MailAddress(model.Email);
            mail.To.Add("seba7964@gmail.com");
            mail.Subject = "Konktaktirajte nas";
            mail.IsBodyHtml = false;
            mail.Body = "You just got a contact email: " + model.Email + "\n" +
                        "Name: " + model.Name + "\n"
                        + "Email: " + model.Message + "\n";

            SmtpClient smtp = new SmtpClient();

            smtp.Send(mail);

            return RedirectToCurrentUmbracoPage();


        }
    }
}