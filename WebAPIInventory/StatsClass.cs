namespace WebAPIInventory
{
    public class StatsClass
    {
        public int Id { get; set; }
        public double Attack { get; set; } = 0;
        public double MagicAttack { get; set; } = 0;
        public double Defense { get; set; } = 0;
        public double MagicDefense { get; set; } = 0;
        public double Evade { get; set; } = 0;
        public double Block { get; set; } = 0;
        public double Resistance { get; set; } = 0;
        public int EquipId { get; set; }
    }
}