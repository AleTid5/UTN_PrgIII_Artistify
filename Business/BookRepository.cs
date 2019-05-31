using Domain.User;
using System;
using System.Collections.Generic;


namespace Repository
{
    public class BookRepository : Repository
    {
        public BookRepository()
        {
            this.Table = "Media_Books";
        }
    }
}
