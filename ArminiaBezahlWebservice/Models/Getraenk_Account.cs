using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArminiaBezahlWebservice.Models
{
    public class Getraenk_Account
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int GetraenkId { get; set; }

        public bool Bezahlt { get; set; }
    }
}
