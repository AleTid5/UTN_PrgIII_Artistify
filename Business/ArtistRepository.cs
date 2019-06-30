using Common;
using Common.Exceptions;
using Common.Senders;
using Common.Transformers;
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

        public new void AuthenticateOrFail(String Email, String Password)
        {
            try {
                this.CheckCredentialsOrFail(Email, Password);
                this.CheckOrFail();
                this.SqlConnection.Close();
                this.UpdateUserLogin(Session.user.Id);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public void Add(Artist artist)
        {
            try {
                int lastID = this.Add((AbstractUser)artist);
                String QueryTemplate = "INSERT INTO {0} (Id, Alias, Manager) " +
                                       "VALUES ({1}, '{2}', {3})";
                String Query = String.Format(QueryTemplate, this.Table,
                                                            lastID,
                                                            artist.Alias,
                                                            //artist.ImageSource,
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

        public void Edit(Artist artist)
        {
            try {
                this.Edit((AbstractUser)artist);
                String QueryTemplate = "UPDATE {0} SET Alias = '{1}' WHERE Id = {2}";
                String Query = String.Format(QueryTemplate, this.Table, artist.Alias, artist.Id);
                this.ExecUpdate(Query);
            } catch (SqlException ex) {
                throw new SqlParsedException(ex.Number, ex.Message);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public Artist FindById(int Id)
        {
            try {
                if (0 == Id) return null;

                String Query = String.Format("SELECT TOP 1 * FROM {0} A INNER JOIN Users U ON A.Id = U.Id WHERE U.Status = 'A' AND A.Id = {1}", this.Table, Id);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.GetRowCasted(this.GetRowCasted());
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public List<Artist> FindAllByManagerId(int ManagerId)
        {
            try {
                if (0 == ManagerId) return null;

                String Query = String.Format("SELECT * FROM {0} A INNER JOIN Users U ON A.Id = U.Id WHERE A.Manager = {1}", this.Table, ManagerId);
                this.ExecSelect(Query);
                List<Artist> artists = new List<Artist>();

                while (this.SqlDataReader.Read())
                    artists.Add(this.GetRowCasted(this.GetRowCasted()));

                return artists;
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public Artist FindByManagerIdAndArtistId(int ManagerId, int ArtistId)
        {
            try {
                String Query = String.Format("SELECT TOP 1 * FROM {0} A INNER JOIN Users U ON A.Id = U.Id WHERE A.Manager = {1} AND A.Id = {2}", this.Table, ManagerId, ArtistId);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.GetRowCasted(this.GetRowCasted());
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        private Artist GetRowCasted(AbstractUser abstractUser)
        {
            return new Artist(abstractUser) {
                Alias = DBTransformer.GetOrDefault(this.SqlDataReader["Alias"], ""),
                ImageSource = DBTransformer.GetOrDefault(this.SqlDataReader["ImageSource"], ""),
                Verified = DBTransformer.GetOrDefault(this.SqlDataReader["Verified"], false),
                ArtistType = new MediaTypeRepository().FindById(DBTransformer.GetOrDefault(this.SqlDataReader["MediaType"], 0)),
                Manager = new ManagerRepository().FindById(DBTransformer.GetOrDefault(this.SqlDataReader["Manager"], 0))
            };
        }

        private void CheckOrFail()
        {
            String QueryTemplate = "SELECT TOP 1 * FROM Users_Artists WHERE Id = {0}";
            String Query = String.Format(QueryTemplate, Session.user.Id);
            this.ExecSelect(Query);
            this.SqlDataReader.Read();
            this.AssertOrFail("El usuario ingresado no es artista");
        }
    }
}
