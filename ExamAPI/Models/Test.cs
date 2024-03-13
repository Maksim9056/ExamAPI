namespace ExamAPI.Models
{
    [Serializable]
    /// <summary>
    /// Справочник тестов
    /// </summary>
    public class Test
    {
        public int Id { get; set; }
        public string Name_Test { get; set; }
        public int Options_Id { get; set; }
    }

}
