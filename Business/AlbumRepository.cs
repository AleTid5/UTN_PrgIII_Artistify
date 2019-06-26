using Common.Transformers;
using Entity;
using Entity.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AlbumRepository : Repository
    {
        public AlbumRepository()
        {
            this.Table = "Albums";
        }

        public Album FindById(int Id)
        {
            try {
                if (0 == Id) return null;

                String Query = String.Format("SELECT TOP 1 * FROM Albums A WHERE A.Status = 'A' AND A.Id = {1}", this.Table, Id);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.GetRowCasted();
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public List<Album> FindAllByMediaType(int mediaType)
        {
            try {
                if (0 == mediaType) return null;

                String Query = String.Format("SELECT * " +
                                             "FROM {0} A " +
                                             "WHERE A.MediaType = {1} " +
                                             "AND A.Status = 'A'",
                                             this.Table,
                                             mediaType);
                this.ExecSelect(Query);
                List<Album> albums = new List<Album>();

                while (this.SqlDataReader.Read())
                    albums.Add(this.GetRowCasted());

                return albums;
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        private Album GetRowCasted()
        {
            return new Album() {
                Id = DBTransformer.GetOrDefault(this.SqlDataReader["Id"], 0),
                Name = DBTransformer.GetOrDefault(this.SqlDataReader["Name"], ""),
                ImageSource = DBTransformer.GetOrDefault(this.SqlDataReader["ImageSource"], ""),
                RegisterDate = this.GetOrNull(this.SqlDataReader["RegisterDate"]),
                ModificationDate = this.GetOrNull(this.SqlDataReader["ModificationDate"]),
                Artist = new ArtistRepository().FindById(DBTransformer.GetOrDefault(this.SqlDataReader["Artist"], 0)),
                MediaType = new MediaTypeRepository().FindById(DBTransformer.GetOrDefault(this.SqlDataReader["MediaType"], 0)),
                Status = new StatusRepository().FindStatusByCode(this.SqlDataReader["Status"].ToString()),
            };
        }
    }
}
