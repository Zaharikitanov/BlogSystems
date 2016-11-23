using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSystem.ViewModels
{
    public class PostViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}