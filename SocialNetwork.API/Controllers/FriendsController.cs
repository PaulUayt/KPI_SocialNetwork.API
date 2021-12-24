using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Models;
using SocialNetwork.BLL.DTO;
using SocialNetwork.BLL.Infrastructure;
using SocialNetwork.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.API.Controllers
{
    public class FriendsController : Controller
    {
        private readonly IFriendsService _friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        [HttpGet(nameof(FindUsersByName))]
        public IActionResult FindUsersByName(string searchText)
        {
            try
            {
                var users = _friendsService.FindByName(searchText);
                List<OpenUserInfoViewModel> openUserInfo = new List<OpenUserInfoViewModel>();
                foreach(var item in users)
                {
                    openUserInfo.Add( new()
                    {
                        Id = item.Id,
                        SurName = item.SurName,
                        Name = item.Name,
                        Patronymic = item.Patronymic
                    });
                }

                return Ok(openUserInfo);
            }
            catch (ValidationException e)
            {
                return Ok($"Error: {e.Message}");
            }
        }

        [HttpGet(nameof(GetAllFriendRequestsToUser))]
        public IActionResult GetAllFriendRequestsToUser(int? userId)
        {
            try
            {
                var requests = _friendsService.GetAllFriendRequestsToUser(userId);

                return Ok(requests);
            }
            catch (ValidationException e)
            {
                return Ok($"Error: {e.Message}");
            }
        }

        [HttpGet(nameof(GetAllFriendRequestsFromUser))]
        public IActionResult GetAllFriendRequestsFromUser(int? userId)
        {
            try
            {
                var requests = _friendsService.GetAllFriendRequestsFromUser(userId);

                return Ok(requests);
            }
            catch (ValidationException e)
            {
                return Ok($"Error: {e.Message}");
            }
        }

        [HttpGet(nameof(GetAllFriends))]
        public IActionResult GetAllFriends(int? userId)
        {
            try
            {
                var users = _friendsService.GetAllRelationships(userId);
                return Ok(users);
            }
            catch (ValidationException e)
            {
                return Ok($"Error: {e.Message}");
            }
        }

        [HttpGet(nameof(GetAllUsersInDB))]
        public IActionResult GetAllUsersInDB(int? userId)
        {
            try
            {
                var users = _friendsService.GetAllUsersInDB(userId);
                List<OpenUserInfoViewModel> openUserInfo = new List<OpenUserInfoViewModel>();
                foreach (var item in users)
                {
                    openUserInfo.Add(new()
                    {
                        Id = item.Id,
                        SurName = item.SurName,
                        Name = item.Name,
                        Patronymic = item.Patronymic
                    });
                }
                return Ok(openUserInfo);
            }
            catch (ValidationException e)
            {
                return Ok($"Error: {e.Message}");
            }
        }

        [HttpPost(nameof(SendRequest))]
        public IActionResult SendRequest(int? from_userId, int? to_userId)
        {
            string result;
            try
            {
                _friendsService.SendRequest(from_userId, to_userId);
                result = "Request send succesfull!";
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }

        [HttpPost(nameof(AddNewChat))]
        public IActionResult AddNewChat(RelationshipsDTO relationships)
        {
            string result;
            try
            {
                _friendsService.AddNewChat(relationships);
                result = "Chat was created succesfull!";
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }

        [HttpPost(nameof(AddNewFriend))]
        public IActionResult AddNewFriend(int requestId)
        {
            string result = "";
            try
            {
                List<FriendRequestDTO> request = (List<FriendRequestDTO>)_friendsService.GetFriendRequestById(requestId);
                _friendsService.AddNewRelationships(requestId);
                result += $"Friend: {_friendsService.GetUserById(request[0].FromUser_Id)} was added in friends User: {_friendsService.GetUserById(request[0].ToUser_Id)}  succesfull!";
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteFriendRequests))]
        public IActionResult DeleteFriendRequests(int request_id)
        {
            string result;
            try
            {
                _friendsService.DeleteFriendRequests(request_id);
                result = "Request was deleted succesfull!";
            }
            catch (ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        } 
    }
}
