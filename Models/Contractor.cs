namespace DotnetContractors.Models
{
    public class Contractor
    {
        public int Id { get; set; }
        public string ContractorId { get; set; }
        public string Name { get; set; }
        public int Wage { get; set; }
        public Profile Creator { get; set; }
    }
}