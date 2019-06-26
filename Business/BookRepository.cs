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
    }
}
