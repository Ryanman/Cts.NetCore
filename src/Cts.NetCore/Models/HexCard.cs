using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Cts.NetCore.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HexCard
    {
        public HexCard()
        {

        }
        public string Name { get; set; }
        public string UUid { get; set; }
        public bool AA { get; set; }
        public string Set { get; set; }
        public string Rarity { get; set; }
        public string Type { get; set; }

    }
}
