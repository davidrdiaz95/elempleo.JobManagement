namespace elempleo.JobManagement.Model.Dto
{
    public class JobOfferDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string JobTitle { get; set; }
		public string Location { get; set; }
		public long Salary { get; set; }
		public int IdTypeContract { get; set; }
		public int IdCompany { get; set; }
		public bool IsActive { get; set; }
		public DateTime DateCreate { get; set; }
	}
}
