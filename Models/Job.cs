namespace DotnetContractors.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int Budget { get; set; }
    }
    public class ContractorJobViewModel : Contractor
    {
        public int ContractorJobId { get; set; }
    }
}