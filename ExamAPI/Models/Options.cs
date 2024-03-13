
namespace ExamAPI.Models
{
    /// <summary>
    /// Параметры
    /// </summary>
    public class Options
    {
        public int Id { get; set; }
        public Answer Id_Answer { get; set; }
        public string Test_Name { get; set; }
        public Questions Questions { get; set; }
        public Questions Questions_Id { get; set; }
        public Test Id_Test { get; set; }
    }
}
