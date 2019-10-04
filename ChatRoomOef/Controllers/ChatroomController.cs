using ChatRoomOef.Data;
using ChatRoomOef.Domain;
using ChatRoomOef.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatRoomOef.Controllers
{
    [Authorize]
    public class ChatroomController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly string userId;

        public ChatroomController(ApplicationDbContext context,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<ChatroomListViewModel> models = new List<ChatroomListViewModel>();
            
            var chatroomids = _context.ChatroomUsers.Where(x => x.UserId == _userManager.GetUserId(User)).Select(x=>x.ChatroomId).ToList();
            var chatrooms = _context.Chatrooms.Where(x => chatroomids.Contains(x.Id));
            foreach (var item in chatrooms)
            {
                models.Add(new ChatroomListViewModel()
                {
                    Id = item.Id,
                    Titel = item.Name
                });
            }
            return View(models);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ChatroomCreateViewModel model)
        {
            Chatroom chatroom = new Chatroom() { CreatorId = _userManager.GetUserId(User), Name = model.Name };
            _context.Chatrooms.Add(chatroom);
            _context.ChatroomUsers.Add(new ChatroomUsers() { ChatroomId=chatroom.Id,UserId= _userManager.GetUserId(User)});
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _context.ChatroomMessages.RemoveRange(_context.ChatroomMessages.Where(x => x.ChatroomId == id));
            _context.ChatroomUsers.RemoveRange(_context.ChatroomUsers.Where(x => x.ChatroomId == id));
            _context.Chatrooms.Remove(_context.Chatrooms.FirstOrDefault(x => x.Id == id));
            return RedirectToAction("Index");
        }
        public IActionResult LeaveChatroom(int id)
        {
            _context.ChatroomUsers.Remove(_context.ChatroomUsers.Where(x => x.ChatroomId == id).FirstOrDefault(y => y.UserId == _userManager.GetUserId(User)));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
