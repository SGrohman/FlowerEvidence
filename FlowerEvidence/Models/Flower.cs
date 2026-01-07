using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FlowerEvidence.Models
{
    public class Flower
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Genus { get; set; }
        public string? Color { get; set; }

        public override string? ToString()
        {
            return $"{Name} {Genus} {Color}";
        }
    }
}
