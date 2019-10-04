using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomOef.Domain
{
    public class UserPicture
    {
        public string UserID { get; set; }
        public byte[] Photo { get; set; }
    }
}
