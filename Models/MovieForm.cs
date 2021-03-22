using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Models
{
    public class MovieForm
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string DirectorFirst { get; set; }
        [Required]
        public string DirectorLast { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        [Range(0, 25)]
        public string Notes { get; set; }
        
        public string Lent { get; set; }

    }
}
