using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mamedia.Src.Domain.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(20)]
        [MinLength(6,ErrorMessage ="طول رمز عبور نباید از 6 کاراکتر کمتر باشد")]
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime BirthDate { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
    }
}
