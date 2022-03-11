using System;

namespace Application.Models.ViewModels
{
    public class CityViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int TimeOffsetInMinutes { get; set; }

        public Guid CountryId { get; set; }
    }
}