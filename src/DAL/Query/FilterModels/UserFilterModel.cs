namespace DAL.Query.FilterModels
{
    public class UserFilterModel : PaginationFilterModel
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int? MinimalNumberOfBookings { get; set; }

        public int? MaximumNumberOfBookings { get; set; }
    }
}