
namespace ExamAPI.Models
{

    [Serializable]
    /// <summary>
    /// Вопросы с ответами
    /// </summary>
    public class QuestionAnswer
    {
        //public QuestionAnswer() { }

        /// <summary>
        /// Id вопроса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Вопросы
        /// </summary>
        public Questions Questions { get; set; }

        /// <summary>
        /// Правильные ответы
        /// </summary>
        public string CorrectAnswers { get; set; }

        /// <summary>
        /// Оценка
        /// </summary>
        public int Grade { get; set; }
        /// <summary>
        /// Один из ответов
        /// </summary>
        public Answer Answer { get; set; }

    }

}
