using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class AspNetUser
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicUrl { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool? Activated { get; set; }
        public int? RoleId { get; set; }
        public string Discriminator { get; set; }
    }
}
