using System.ComponentModel.DataAnnotations;

namespace LearningDataStorage
{
    /// <summary>
    /// Автор.
    /// </summary>
    public class Author
    {
        public int Id { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Биография.
        /// </summary>
        public string Biography { get; set; }
    }
}
