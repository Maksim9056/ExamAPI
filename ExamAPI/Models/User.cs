
namespace ExamAPI.Models
{
    [Serializable]
    /// <summary>
    /// Справочник Пользователей
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя или работника
        /// </summary>
        public string Name_Employee { get; set; }
        /// <summary>
        /// Пароль 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public string DataMess { get; set; }
        /// <summary>
        /// id роли 
        /// </summary>

        public Filles Email { get; set; }
        public int Id_roles_users { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        public string Employee_Mail { get; set; }
    }
}
