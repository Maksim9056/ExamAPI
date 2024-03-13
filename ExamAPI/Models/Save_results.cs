
namespace ExamAPI.Models
{
    [Serializable]
    /// <summary>
    /// Сохраняет результат экзамена
    /// </summary>
    public class Save_results
    {
        public int Id { get; set; }
        public Questions Questions { get; set; }
        public Test Name_Test { get; set; }
        public string Users_Answers_Questions { get; set; }
        public Exams Exam_id { get; set; }
        public string Date_of_Result_Exam_Endings { get; set; }
        public string Name_Users { get; set; }
        public int Resukts_exam { get; set; }
        public User User_id { get; set; }
    }
}
