using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fiszki.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double LevelHard{ get; set; }
        public int Color { get; set; }
        public bool isPolishTranslation { get; set; }
    }
}
