namespace Cts.NetCore.Models
{
    public class HexPrice
    {
        public Platinum platinum { get; set; }
        public Gold gold { get; set; }

        public class Platinum
        {
            public string total { get; set; }
            public string quantity { get; set; }
            public int minimum { get; set; }
            public int maximum { get; set; }
            public int average { get; set; }
            public int median { get; set; }
        }

        public class Gold
        {
            public string total { get; set; }
            public string quantity { get; set; }
            public int minimum { get; set; }
            public int maximum { get; set; }
            public int average { get; set; }
            public int median { get; set; }
        }

        public bool Empty
        {
            get
            {
                return (platinum == null &&
                    gold == null);
            }
        }
    }
}
