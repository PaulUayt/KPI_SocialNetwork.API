using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.BLL.DTO;

namespace SocialNetwork.API.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet(nameof(GetChatWithUser))]
        public IActionResult GetChatWithUser(int? messList_id)
        {
            try
            {
                var chat = _chatService.GetChatByMessListId(messList_id);
                return Ok(chat);
            }
            catch (ValidationException e)
            {
                return Ok($"Error: {e.Message}");
            }
        }

        [HttpPost(nameof(SendMess))]
        public IActionResult SendMess(MessListDTO messListDTO, string text)
        {
            string result;
            try
            {
                _chatService.SendMess(messListDTO, text);
                result = "Message send succesfull!";
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }
    }
}
