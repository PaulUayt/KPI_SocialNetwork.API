using Microsoft.AspNetCore.Mvc;
using System;
using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.BLL.Interfaces;

namespace SocialNetwork.API.Controllers
{
    public class AutorizationController : Controller
    {
        private readonly IAutorizationService _autorizationService;

        public AutorizationController(IAutorizationService autorizationService)
        {
            _autorizationService = autorizationService;
        }

        [HttpGet(nameof(LoginUser))]
        public IActionResult LoginUser(string email, string password)
        {
            try
            {
                var user = _autorizationService.LogIn(email, password);
                return Ok(user);
            }
            catch (ValidationException e)
            {
                return Ok($"Error: {e.Message}");
            }
        }
    }
}
