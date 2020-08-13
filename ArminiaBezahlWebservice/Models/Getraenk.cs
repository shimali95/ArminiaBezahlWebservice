using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace ArminiaBezahlWebservice.Models
{
    public class Getraenk
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public double Preis { get; set; }
    }
}
