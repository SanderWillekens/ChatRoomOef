using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomOef.Domain
{
    public class Chatroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatorId { get; set; }
        public byte[] Photo { get; set; }
        public ICollection<ChatroomUsers> Users { get; set; }
        public ICollection<ChatroomMessage> Messages { get; set; }
    }
}
