using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.Core.Models
{
   public class UserModel
    {
        public int Id { get; set; }
        [DisplayName("أسم العميل")]
        [Required]

        public string FristName { get; set; }
        [DisplayName("أسم الاب")]
        [Required]

        public string LastName { get; set; }
        [DisplayName("رقم الهاتف")]
        [Required]
        public string MobileNo { get; set; }

        [DisplayName("البريد الالكتروني")]

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("مفعل")]

        public bool IsActive { get; set; }
    }
}
