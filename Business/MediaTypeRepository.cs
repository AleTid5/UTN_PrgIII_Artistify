using Entity;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class MediaTypeRepository : Repository
    {
        public MediaTypeRepository()
        {
            this.Table = "MediaTypes";
        }

        public void AddGender(Gender gender)
        {
            try {
                String QueryTemplate = "INSERT INTO {0} (Name, MediaType, ParentGender) VALUES ('{1}', {2}, {3})";
                String Query = String.Format(QueryTemplate, this.Table, gender.Name, gender.MediaType, gender.ParentGender);
                this.ExecInsert(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public void EditGender(Gender gender)
        {
            try {
                String QueryTemplate = "UPDATE {0} SET Name = '{1}', MediaType = {2}, ParentGender = {3}, Status = '{4}' WHERE Id = {5}";
                String Query = String.Format(QueryTemplate, this.Table, gender.Name, gender.MediaType.Id, gender.ParentGender.Id, gender.Status.Code, gender.Id);
                this.ExecInsert(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public void RemoveGender(Gender gender)
        {
            try {
                String QueryTemplate = "UPDATE {0} SET Status = 'B' WHERE Id = {1}";
                String Query = String.Format(QueryTemplate, this.Table, gender.Id);
                this.ExecUpdate(Query);
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public MediaType GetMediaType(int Id)
        {
            try {
                String Query = String.Format("SELECT TOP 1 * FROM {0} WHERE Id = {1}", this.Table, Id);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.GetRowCasted();
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        public List<MediaType> FindAll()
        {
            try {
                String Query = String.Format("SELECT * FROM {0} ORDER BY Status ASC, Type ASC", this.Table);
                this.ExecSelect(Query);

                List<MediaType> categories = new List<MediaType>();

                while (this.SqlDataReader.Read())
                    categories.Add(this.GetRowCasted());

                return categories;
            } catch (Exception ex) {
                throw ex;
            } finally {
                this.SqlConnection.Close();
            }
        }

        private MediaType GetRowCasted()
        {
            if (!this.SqlDataReader.HasRows)
                return new MediaType();

            return new MediaType {
                Id = int.Parse(this.SqlDataReader["Id"].ToString()),
                Type = this.SqlDataReader["Type"].ToString(),
                Status = (new StatusRepository()).GetStatus(this.SqlDataReader["Status"].ToString())
            };
        }
    }
}
