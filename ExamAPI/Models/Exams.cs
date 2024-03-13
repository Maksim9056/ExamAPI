namespace ExamAPI.Models
{
    [Serializable]
    /// <summary>
    /// Справочник экзаменов
    /// </summary>
    public class Exams
    {
        public int Id { get; set; }
        public string Name_exam { get; set; }
    }
}
