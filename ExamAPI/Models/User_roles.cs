
namespace ExamAPI.Models
{

    /// <summary>
    /// Для ролей у пользователей  зарегистрировались
    /// </summary>
    public class User_roles
    {
        public int Id { get; set; }
        public Roles Id_roles { get; set; }
        public User User_id { get; set; }
    }
}
