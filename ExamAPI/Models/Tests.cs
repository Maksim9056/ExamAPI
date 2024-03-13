namespace ExamAPI.Models
{

    [Serializable]
    /// <summary>
    /// Класс  для Test запоковываем
    /// </summary>
    public class Tests
    {
        public Tests() { }
        public Test[] TEST { get; set; }
        public Tests(Test[] test)
        {
            TEST = test;
        }
    }
}
