using AWork.Core.Communication.Mediator;
using AWork.Core.Messages;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.WebAPI.Core.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        //Notificação
        protected ICollection<string> _notifications = new List<string>();
        protected bool UserIsAuthenticated { get; }

        protected MainController() { }
        
        //Retorno Personalizado validado ModelState
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifierError(modelState);
            return CustomResponse();
        }
        //Retorno padrão, sucesso 200 e erro 500
        protected ActionResult CustomResponse(object result = null)
        {
            if (ActionIsValid()) return Ok(new { success = true, data = result });
            else return BadRequest(new { success = false, errors = GetNotification() });
        }
        
        private IEnumerable<string> GetNotification()
        {
            return _notifications.ToList();
        }

        //Validar a ModelState e Notificar
        protected void NotifierError(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                foreach (var erro in modelState.Values.SelectMany(erros => erros.Errors))
                {
                    var msgError = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    NotifierError(erro.ErrorMessage);
                }
            }
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                NotifierError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        //Notificador
        protected void NotifierError(string message)
        {
            _notifications.Add(message);
        }
        //Verifica sem tem alguma outra notificação, mesmo em outra camada
        protected bool ActionIsValid()
        {
            return !_notifications.Any();
        }
        protected void ClearErrors()
        {
            _notifications.Clear();
        }
      
    }
}