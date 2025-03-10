namespace elempleo.JobManagement.Repository.Entity
{
	public class TypeContractEntity : Base.Entity
	{
		public string Name { get; set; }
		public IEnumerable<JobOfferEntity>? JobOffers { get; set; }
	}
}
