using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.BLL.Interfaces;
using System;
using System.Collections.Generic;

namespace SocialNetwork.API.Controllers
{
    public class MessListController : Controller
    {
        private readonly IMessListService _messListService;

        public MessListController(IMessListService messListService)
        {
            _messListService = messListService;
        }

        [HttpGet(nameof(GetAllChats))]
        public IActionResult GetAllChats(int userId)
        {
            try
            {
                if (_messListService.GetAllMessLists(userId).Count == 0) throw new ValidationException("User has't chats...", "");
                var messlist = _messListService.GetAllMessLists(userId);
                return Ok(messlist);
            }
            catch (ValidationException e)
            {
                return ViewBag($"Error - {e.Message}");
            }            
        }
    }
}
