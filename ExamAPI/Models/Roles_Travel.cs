namespace ExamAPI.Models
{
    public class Roles_Travel
    {
        Roles_Travel() { }
        public Roles[] Roles { get; set; }
        public Roles_Travel(Roles[] roles)
        {
            Roles = roles;
        }
    }

}
