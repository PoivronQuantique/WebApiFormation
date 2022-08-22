namespace SelfieAWookie.API.Application.DTO
{
    public class SelfieDTO
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int WookieId { get; set; }
        public int ImageId { get; set; }
    }
}
