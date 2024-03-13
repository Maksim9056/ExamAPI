using System.Text.Json;
using System.Text;

namespace ExamAPI.Models
{
    [Serializable]
    public class Filles
    {
        public Filles() { }

        /// <summary>
        /// Id Filles
        /// </summary>
        public int Id { get; set; }

        // Преобразование массива байтов Name в строку Base64 для сериализации в JSON
        //public string NameBase64
        //{
        //    get => Convert.ToBase64String(Name);
        //    set => Name = Convert.FromBase64String(value);
        //}

        //[JsonIgnore] // Игнорирование поля Name при сериализации JSON
        public byte[] Name { get; set; }

        public Filles(int id, byte[] name)
        {
            Id = id;
            Name = name;
        }

        public byte[] ConvertToBytes()
        {
            string json = JsonSerializer.Serialize(this); // Сериализация объекта в формат JSON
            return Encoding.Default.GetBytes(json); // Преобразование строки JSON в массив байтов с использованием UTF-8
        }

        // Для десериализации объекта из массива байтов, если это нужно
        public static Filles ConvertFromBytes(byte[] bytes)
        {
            string jsonString = Encoding.Default.GetString(bytes); // Преобразование массива байтов в строку с использованием UTF-8
            return JsonSerializer.Deserialize<Filles>(jsonString); // Десериализация из строки JSON
        }
    }
}
