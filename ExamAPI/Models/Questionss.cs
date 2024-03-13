namespace ExamAPI.Models
{

    public class Questionss
    {
        Questionss() { }
        public Questions[] Quest { get; set; }
        public Questionss(Questions[] quest)
        {
            Quest = quest;
        }
    }
}
