namespace elempleo.JobManagement.Repository.Entity
{
	public class CompanyEntity : Base.Entity
	{
		public string Address { get; set; }
		public long Phone { get; set; }
		public string Description { get; set; }
		public int IdUser { get; set; }
		public IEnumerable<JobOfferEntity>? JobOffer { get; set; }
	}
}
