namespace DotnetApi1.Models
{
    public class Shirt
    {
        public Guid Id { get; set; }
        public string Colour { get; set; } = string.Empty; 
        public string Type {  get; set; } = string.Empty;
        public string Texture { get; set; } = string.Empty;
        public string Material {  get; set; } = string.Empty;
    }
}
