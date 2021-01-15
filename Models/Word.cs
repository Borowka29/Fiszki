using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fiszki.Models
{
    public class Word
    {
        [Key]
        public int IdWord { get; set; }
        public string PolishVersion { get; set; }
        public string EnglishVersion { get; set; }
    }
}
