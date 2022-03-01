namespace DAL.Entities
{
    public class ImageEntity : Entity
    {
        public string Extension { get; set; }

        public byte[] Content { get; set; }
    }
}