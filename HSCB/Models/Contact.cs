using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HSCB.Models
{
    public class Contact
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        public string Name { get; set; }

        [StringLength(maximumLength: 14, MinimumLength = 10, ErrorMessage = "Không đúng định dạng SĐT")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Không đúng định dạng mail")]
        public string Email { get; set; }

        public string Status { get; set; }
    }
}