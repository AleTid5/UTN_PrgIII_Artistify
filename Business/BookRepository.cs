using Entity.Media;
using Entity.User;
using System;
using System.Collections.Generic;


namespace Repository
{
    public class BookRepository : MediaRepository
    {
        public BookRepository()
        {
            this.Table = "Media_Books";
        }

        public void Add(Book book)
        {
            try {
                String QueryTemplate = "INSERT INTO {0} (Id) VALUES ({1})";
                String Query = String.Format(QueryTemplate, this.Table, book.Id);
                this.ExecInsert(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }
    }
}
