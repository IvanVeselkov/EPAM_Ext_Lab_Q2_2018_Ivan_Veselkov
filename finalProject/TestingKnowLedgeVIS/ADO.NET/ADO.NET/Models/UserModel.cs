namespace ADO.NET.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPasswd { get; set; }
        public Role UserRole { get; set; }
    }
}