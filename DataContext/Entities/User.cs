

namespace LoginManagemet.DataContext.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public bool IsEnable { get; set; }

    }
}
