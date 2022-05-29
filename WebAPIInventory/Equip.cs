namespace WebAPIInventory
{
    public class Equip : Item
    {
        public string Type { get; set; }
        public bool Enchanted { get; set; }
        public StatsClass Stats { get; set; }
    }
}
