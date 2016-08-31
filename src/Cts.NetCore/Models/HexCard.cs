namespace Cts.NetCore.Models
{
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

        public bool Empty
        {
            get
            {
                return (string.IsNullOrWhiteSpace(Name) &&
                    string.IsNullOrWhiteSpace(Set) &&
                    string.IsNullOrWhiteSpace(Rarity));
            }
        }
    }
}
