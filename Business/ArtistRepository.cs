using Common.Exceptions;
using Common.Senders;
using Entity.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ArtistRepository : UserRepository
    {
        public ArtistRepository()
        {
            this.Table = "Users_Artists";
        }

        public void Add(Artist artist)
        {
            try {
                int lastID = this.Add((AbstractUser)artist);
                String QueryTemplate = "INSERT INTO {0} (Id, Alias, ImageSource, Manager) " +
                                       "VALUES ({1}, '{2}', '{3}', {4})";
                String Query = String.Format(QueryTemplate, this.Table,
                                                            lastID,
                                                            artist.Alias,
                                                            artist.ImageSource,
                                                            artist.Manager.Id);
                this.ExecInsert(Query);
                EmailSender.ArtistAdd(artist);
            } catch (SqlException ex) {
                throw new SqlParsedException(ex.Number, ex.Message);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }
    }
}
