namespace elempleo.JobManagement.Model.Dto
{
	public class UserDto
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public long Dni { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public int IdRol { get; set; }
		public int IdTypeDni { get; set; }
		public CompanyDto? Company { get; set; }
		public CandidateDto? Candidate { get; set; }
	}
}
