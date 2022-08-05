using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reperto.Models
{
    public class Repertoire
    {
        public int RepertoireId { get; set; }
        public string Name { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
