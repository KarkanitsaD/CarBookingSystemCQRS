using System;

namespace Application.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public Guid? UserImageId { get; set; }

        public RoleViewModel[] Roles { get; set; }
    }
}