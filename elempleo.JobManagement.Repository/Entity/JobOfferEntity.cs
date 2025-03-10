namespace elempleo.JobManagement.Repository.Entity
{
    public class JobOfferEntity : Base.Entity
    {
        public string Name { get; set; }
		public string Description { get; set; }
		public string JobTitle { get; set; }
		public string Location { get; set; }
		public long Salary { get; set; }
		public int IdTypeContract { get; set; }
		public int IdCompany { get; set; }
		public bool IsActive { get; set; }
		public CompanyEntity? Company { get; set; }
		public TypeContractEntity? TypeContract { get; set; }
	}
}
