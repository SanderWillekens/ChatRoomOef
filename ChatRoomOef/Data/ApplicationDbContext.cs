using System;
using System.Collections.Generic;
using System.Text;
using ChatRoomOef.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatRoomOef.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Chatroom> Chatrooms { get; set; }
        public DbSet<ChatroomMessage> ChatroomMessages { get; set; }
        public DbSet<ChatroomUsers> ChatroomUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserPicture> UserPictures { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ChatroomUsers>().HasKey(x => new { x.ChatroomId, x.UserId });
            builder.Entity<ChatroomMessage>().HasKey(x => new { x.ChatroomId, x.MessageId });
            builder.Entity<UserPicture>().HasKey(x => new { x.UserID });
            base.OnModelCreating(builder);
        }
    }
}
