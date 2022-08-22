namespace SelfieAWookie.Core.Selfies.Domain
{
    public class Selfie
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public int WookieId { get; set; }
        public Wookie Wookie { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
