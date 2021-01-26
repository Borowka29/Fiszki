using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fiszki.Models
{
    [Table("Word")]
    public class Word
    {
        [Key]
        public int Id { get; set; }
        public string PolishVersion { get; set; }
        public string EnglishVersion { get; set; }
    }
}
