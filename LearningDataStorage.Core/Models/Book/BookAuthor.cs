using System;
using System.Collections.Generic;

namespace LearningDataStorage.Core.Models
{
    public class BookAuthor : IHasPhoto<BookAuthorPhoto>
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<BookAuthorLink> BookAuthorLinks { get; set; }

        public ICollection<BookAuthorPhoto> Photo { get; set; }

        public string Biography { get; set; }

    }
}
