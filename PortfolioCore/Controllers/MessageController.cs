using Microsoft.AspNetCore.Mvc;
using PortfolioCore.Context;
using PortfolioCore.Entities;
using System.Net.Mime;

namespace PortfolioCore.Controllers
{
    public class MessageController : Controller
    {
        PortfolioContext context = new PortfolioContext();

        public IActionResult MessageList()
        {
            var values = context.Messages.ToList().TakeLast(6);
            return View(values.ToList());
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            message.SendDate = DateTime.Now;
            context.Messages.Add(message);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Message send successfully";
            return RedirectToAction("MessageList");
        }

        [Route("/Message/ChangeToTrue/{messageId}")]
        [HttpGet]
        public IActionResult ChangeToTrue(int messageId)
        {
            var message = context.Messages.Find(messageId);
            message.IsRead= true;
            context.Messages.Update(message);
            context.SaveChanges();  
            return RedirectToAction("MessageList");
        }

        [Route("/Message/ChangeToFalse/{messageId}")]
        [HttpGet]
        public IActionResult ChangeToFalse(int messageId)
        {
            var message = context.Messages.Find(messageId);
            message.IsRead = false;
            context.Messages.Update(message);
            context.SaveChanges ();
            return RedirectToAction("MessageList");
        }
        
        public IActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("MessageList");
        }
    }
}
