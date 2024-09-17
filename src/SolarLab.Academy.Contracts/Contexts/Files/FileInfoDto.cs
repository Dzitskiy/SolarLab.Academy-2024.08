namespace SolarLab.Academy.Contracts.Contexts.Files
{
    public class FileInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public DateTime Created { get; set; }
    }
}
