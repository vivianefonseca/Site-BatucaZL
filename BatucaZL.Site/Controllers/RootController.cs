using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BatucaZL.Site.Services;
using BatucaZL.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace BatucaZL.Site.Controllers
{
    public class RootController : Controller
    {
        //private IEmailService _emailService;

        //public RootController(IEmailService emailService)
        //{
        //    _emailService = emailService;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }
        
        [HttpPost("contato")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact([FromBody]ContatoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var spamState = VerifyNoSpam(model);
                    //if (!spamState.Success)
                    //{
                    //    return BadRequest(new { Reason = spamState.Reason });
                    //}

                    //await _emailService.EnviarEmail(model.Nome, model.Email, model.Assunto, model.Mensagem);

                    return Ok(new { Success = true, Message = "E-mail enviado com sucesso" });
                }
                else
                {
                    return BadRequest(new { Reason = "Desculpe... Falha ao enviar mensagem." });
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError("Failed to send email from contact page", ex);
                return BadRequest(new { Reason = "Error Occurred" });
            }

        }
    }
}