namespace Application.ViewModels
{
    public class BookingPointEditViewModel
    {
        public string Title { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public ExtraServiceViewModel[] ExtraServices { get; set; }
    }
}