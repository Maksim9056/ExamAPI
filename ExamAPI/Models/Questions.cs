namespace ExamAPI.Models
{
    /// <summary>
    /// Справочник вопросов для теста
    /// </summary>
    [Serializable]
    public class Questions
    {
        public int Id { get; set; }

        /// <summary>
        /// Наименование вопроса
        /// </summary>
        public string QuestionName { get; set; }

        /// <summary>
        /// Правильный ответ
        /// </summary>
        public string AnswerTrue { get; set; }

        /// <summary>
        /// Оценка вопроса
        /// </summary>
        public int Grade { get; set; }

        ///// <summary>
        ///// Выбранные ответы
        ///// </summary>
        //public List<Answer> allAnswers { get; set; }

    }
}
