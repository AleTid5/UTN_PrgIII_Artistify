using Common.Exceptions;
using Common.Transformers;
using Entity.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MediaRepository : Repository
    {
        public MediaRepository()
        {
            this.Table = "Media";
        }

        public List<AbstractMedia> FindAllByAlbumId(int albumId)
        {
            try {
                if (0 == albumId) return null;

                String Query = String.Format("SELECT * FROM {0} WHERE Album = {1} AND Status = 'A'", this.Table, albumId);
                this.ExecSelect(Query);
                List<AbstractMedia> mediaContent = new List<AbstractMedia>();

                while (this.SqlDataReader.Read())
                    mediaContent.Add(this.GetRowCasted());

                return mediaContent;
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public void AddReproducedTime(int mediaId)
        {
            try {
                String Query = String.Format("UPDATE {0} SET ReproducedTimes = ReproducedTimes + 1 WHERE Id = {1}", this.Table, mediaId);
                this.ExecUpdate(Query);
                this.SqlDataReader.Read();
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public void SetRating(int userId, int mediaId, int rating)
        {
            try {
                String Query = String.Format(
                    "BEGIN TRAN " +
                      "IF EXISTS(SELECT * FROM Users_Media_Rating WHERE UserId = {0} AND MediaId = {1}) BEGIN " +
                         "UPDATE Users_Media_Rating SET MediaRating = {2} WHERE UserId = {0} AND MediaId = {1} " +
                      "END " +
                      "ELSE " +
                      "BEGIN " +
                         "INSERT INTO Users_Media_Rating(UserId, MediaId, MediaRating) VALUES({0}, {1}, {2}) " +
                      "END " +
                    "COMMIT TRAN", userId, mediaId, rating);
                this.ExecUpdate(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public int Add(AbstractMedia media)
        {
            try {
                String QueryTemplate = "INSERT INTO {0} (Album, Name, Gender, Category, Size, Source) VALUES ({1}, '{2}', {3}, {4}, '{5}', '{6}')";
                String Query = String.Format(QueryTemplate, this.Table, media.Album.Id, media.Name, media.Gender.Id, media.Category.Id, media.Size, media.Source);
                this.ExecInsert(Query);
                this.SqlConnection.Close();
                Query = String.Format("SELECT MAX(Id) AS Id FROM {0}", this.Table);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return DBTransformer.GetOrDefault(this.SqlDataReader["Id"], 0);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public void Edit(AbstractMedia media)
        {
            try {
                String QueryTemplate = "UPDATE {0} SET Album = {1}, Name = {2}, Gender = {3}, Category = {4}, Size = '{5}', Source = '{6}', Status = '{7}' WHERE Id = {8}";
                String Query = String.Format(QueryTemplate, this.Table, media.Album.Id, media.Name, media.Gender.Id, media.Category.Id, media.Size, media.Source, media.Status.Code, media.Id);
                this.ExecUpdate(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public void Remove(AbstractMedia media)
        {
            try {
                String QueryTemplate = "UPDATE {0} SET Status = 'B' WHERE Id = {1}";
                String Query = String.Format(QueryTemplate, this.Table, media.Id);
                this.ExecUpdate(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        protected AbstractMedia GetRowCasted()
        {
            if (!this.SqlDataReader.HasRows)
                throw new SqlParsedException(100);

            return new AbstractMedia {
                Id = int.Parse(this.SqlDataReader["Id"].ToString()),
                Name = this.SqlDataReader["Name"].ToString(),
                Rating = DBTransformer.GetOrDefault(this.SqlDataReader["Rating"], 0),
                Size = DBTransformer.GetOrDefault(this.SqlDataReader["Size"], "0"),
                ReproducedTimes = DBTransformer.GetOrDefault(this.SqlDataReader["ReproducedTimes"], 0),
                Source = DBTransformer.GetOrDefault(this.SqlDataReader["Source"], null),
                RegisterDate = this.GetOrNull(this.SqlDataReader["RegisterDate"]),
                Status = (new StatusRepository()).FindStatusByCode(this.SqlDataReader["Status"].ToString()),
                Album = new AlbumRepository().FindById(DBTransformer.GetOrDefault(this.SqlDataReader["Album"], 0)),
                Category = new CategoryRepository().FindById(DBTransformer.GetOrDefault(this.SqlDataReader["Category"], 0)),
                Gender = new GenderRepository().FindById(DBTransformer.GetOrDefault(this.SqlDataReader["Gender"], 0))
            };
        }
    }
}
