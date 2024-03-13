namespace ExamAPI.Models
{
    [Serializable]
    /// <summary>
    /// Класс Regis_users для регестрации пользователей
    /// </summary>
    public class Regis_users
    {
        public Regis_users() { }
        public int Id { get; set; }
        public string Name_Employee { get; set; }
        public string Password { get; set; }

        public Roles Rechte { get; set; }
        public string Employee_Mail { get; set; }

        public int Filles { get; set; }

        public Regis_users(int id, string name_Employee, string password, Roles rechte, string @Mail, int files)
        {
            Id = id;
            Name_Employee = name_Employee;
            Password = password;
            Rechte = rechte;
            Employee_Mail = @Mail;
            Filles = files;
        }
    }

}
