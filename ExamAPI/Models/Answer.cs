namespace ExamAPI.Models
{
    /// <summary>
    /// Ответ
    /// </summary>
    /// 
    public class Answer
    {
        public int Id { get; set; }

        /// <summary>
        /// Ответ описание
        /// </summary>
        public string AnswerOptions { get; set; }

        /// <summary>
        /// Признак правильного ответа
        /// </summary>
        public bool CorrectAnswers { get; set; }

    }
}
