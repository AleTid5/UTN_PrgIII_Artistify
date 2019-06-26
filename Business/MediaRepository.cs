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
    }
}
