using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Models.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<MovieForm> Movie { get; set; }

        public MovieForm MovieForm { get; set; }
    }
}
