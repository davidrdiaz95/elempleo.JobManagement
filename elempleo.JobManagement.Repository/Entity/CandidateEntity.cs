namespace elempleo.JobManagement.Repository.Entity
{
	public class CandidateEntity : Base.Entity
	{
		public string Address { get; set; }
		public long Phone { get; set; }
		public string Profile { get; set; }
		public int IdUser { get; set; }
	}
}
