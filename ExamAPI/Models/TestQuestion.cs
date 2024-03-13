
namespace ExamAPI.Models
{

    [Serializable]
    /// <summary>
    /// Тест с вопросами
    /// </summary>
    public class TestQuestion
    {
        public TestQuestion() { }

        /// <summary>
        /// Id Теста с вопросами
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тест, к которому относится вопрос
        /// </summary>
        public Test IdTest { get; set; }

        /// <summary>
        /// Вопросы
        /// </summary>
        public Questions IdQuestions { get; set; }
    }

}
