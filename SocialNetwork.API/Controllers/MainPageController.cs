using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.BLL.Interfaces;

namespace SocialNetwork.API.Controllers
{
    public class MainPageController : Controller
    {
        private readonly IMainPageService _mainPageService;

        public MainPageController(IMainPageService mainPageService)
        {
            _mainPageService = mainPageService;
        }

        [HttpGet(nameof(InfoAboutUser))]
        public IActionResult InfoAboutUser(int userId)
        {
            try
            {
                var info = _mainPageService.GetUserById(userId);
                return Ok(info);
            }
            catch (ValidationException e)
            {
                return Ok($"Error - {e.Message}");
            }
        }

        [HttpGet(nameof(CountFriends))]
        public IActionResult CountFriends(int userId)
        {
            try
            {
                int countF = _mainPageService.GetFriendsCount(userId);
                return Ok(countF);
            }
            catch (ValidationException e)
            {
                return Ok($"Error - {e.Message}");
            }
        }
    }
}
