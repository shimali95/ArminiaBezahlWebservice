using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArminiaBezahlWebservice.Models
{
    [Serializable]
    public class Account
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Kneipname { get; set; }

        public byte[] Passwort { get; set; }
    }
}
