using Entity.Media;
using Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class MusicRepository : MediaRepository
    {
        public MusicRepository()
        {
            this.Table = "Media_Musics";
        }

        public void Add(Music music)
        {
            try {
                String QueryTemplate = "INSERT INTO {0} (Id) VALUES ({1})";
                String Query = String.Format(QueryTemplate, this.Table, music.Id);
                this.ExecInsert(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }
    }
}
