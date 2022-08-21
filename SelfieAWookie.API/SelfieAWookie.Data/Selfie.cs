namespace SelfieAWookie.Core.Selfies.Domain
{
    public class Selfie
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public Wookie WookieProprietaire { get; set; }
    }
}
