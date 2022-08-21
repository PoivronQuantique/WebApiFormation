namespace SelfieAWookie.Core.Selfies.Domain
{
    public class Selfie
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public string Titre { get; set; }
        public Wookie Wookie { get; set; }
    }
}
