using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomOef.Models
{
    public class ChatroomCreateViewModel
    {
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}
