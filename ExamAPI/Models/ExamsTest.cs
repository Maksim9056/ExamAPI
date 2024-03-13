
namespace ExamAPI.Models
{
    [Serializable]
    /// <summary>
    /// Взаимосвязь экзамена и тестов которые в него входят
    /// </summary>
    public class ExamsTest
    {
        public int Id { get; set; }
        public Exams Exams { get; set; }
        public Test Test { get; set; }
    }

}
