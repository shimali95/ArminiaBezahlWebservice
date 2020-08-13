using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArminiaBezahlWebservice.Models
{
    public class EinzelaustellungGetraenke
    {
        public string Titel { get; set; }
        public int Anzahl { get;set; }
        public double Preis { get; set; }
    }
}
