using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cts.NetCore.Models.ViewModels
{
    public class IndexViewModel
    {
        public HexCard Card { get; set; }
        public HexPrice CardPrice { get; set; }
        public string CardSearchName { get; set; }
        public decimal ResponseTime { get; set; }
        //Price Data
    }
}
