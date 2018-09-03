namespace ADO.NET.Models
{
    public class UserModel
    {
        public int UserId { get; set; }//todo не нужно в полях дублировать название сущности
        public string UserLogin { get; set; }
        public string UserPasswd { get; set; }
        public string UserRole { get; set; }
    }
}