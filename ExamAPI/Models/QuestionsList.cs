namespace ExamAPI.Models
{
    [Serializable]
    public class QuestionsList
    {
        public List<Questions> QuestionList { get; set; } = new List<Questions>();
    }

}
