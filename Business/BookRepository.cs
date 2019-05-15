using Domain.User;
using System;
using System.Collections.Generic;


namespace Business
{
    public class BookRepository : Repository
    {
        public BookRepository()
        {
            this.Table = "Media_Books";
        }
    }
}
