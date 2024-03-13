//using static ExamAPI.Models.add;

namespace ExamAPI.Models
{

    [Serializable]
    /// <summary>
    /// Экзамен
    /// </summary>
    public class Exam
    {
        public int Id { get; set; }
        public string Name_Exam { get; set; }
        public User User { get; set; }
        public Questions Questtion { get; set; }
        public Exams Exams { get; set; }
        public DateTime Data_of_Exam { get; set; }
        /// <summary>
        /// Оценка экзамена
        /// </summary>
        public int Grade_Exam { get; set; }
    }
}
