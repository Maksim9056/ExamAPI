namespace ExamAPI.Models
{
    [Serializable]
    /// <summary>
    ///Тест вопросами
    /// </summary>
    public class Questions_Travel
    {
        public Questions_Travel() { }

        /// <summary>
        ///Id  Тест вопросами
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Названия теста
        /// </summary>
        public string Name_Test { get; set; }
        /// <summary>
        /// Вопросы
        /// </summary>
        public string Questions { get; set; }
        /// <summary>
        /// Правильный ответ
        /// </summary>
        public string Answer_True { get; set; }
        /// <summary>
        /// Оценка
        /// </summary>
        public string Grade_Quessions { get; set; }

        /// <summary>
        /// Выборка вопросов несколько
        /// </summary>
        public int Answer_id { get; set; }
        public Questions_Travel(int id, string name_Test, string questions, string answer_True, string grade_Quessions, int answer_id)
        {
            Id = id;
            Name_Test = name_Test;
            Questions = questions;
            Answer_True = answer_True;
            Grade_Quessions = grade_Quessions;
            Answer_id = answer_id;
        }
    }

}
