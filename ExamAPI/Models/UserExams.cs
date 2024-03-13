
namespace ExamAPI.Models
{
    [Serializable]
    /// <summary>
    /// Взаимосвязь Пользователй и назначенных экзаменов
    /// </summary>
    public class UserExams
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Exams Exams { get; set; }
    }

}
