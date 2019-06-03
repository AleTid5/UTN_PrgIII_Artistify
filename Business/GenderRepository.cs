using Common.Transformers;
using Entity;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class GenderRepository : Repository
    {
        public GenderRepository()
        {
            this.Table = "Genders";
        }

        public void AddGender(Gender gender)
        {
            try
            {
                String QueryTemplate = "INSERT INTO {0} (Name, MediaType, ParentGender) VALUES ('{1}', {2}, {3})";
                String Query = String.Format(QueryTemplate, this.Table, gender.Name, gender.MediaType.Id, gender.ParentGender.Id);
                this.ExecInsert(Query);
            } catch (Exception ex)
            {
                throw ex;
            } finally
            {
                this.SqlConnection.Close();
            }
        }

        public void EditGender(Gender gender)
        {
            try
            {
                String QueryTemplate = "UPDATE {0} SET Name = '{1}', MediaType = {2}, ParentGender = {3}, Status = '{4}' WHERE Id = {5}";
                String Query = String.Format(QueryTemplate, this.Table, gender.Name, gender.MediaType.Id, gender.ParentGender.Id, gender.Status.Code, gender.Id);
                this.ExecInsert(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlConnection.Close();
            }
        }

        public void RemoveGender(Gender gender)
        {
            try
            {
                String QueryTemplate = "UPDATE {0} SET Status = 'B' WHERE Id = {1}";
                String Query = String.Format(QueryTemplate, this.Table, gender.Id);
                this.ExecUpdate(Query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlConnection.Close();
            }
        }

        public Gender GetGender(int Id)
        {
            try
            {
                String Query = String.Format(
                    "SELECT TOP 1 {0}.*," +
                    "(SELECT ParentGender.Id FROM {0} AS ParentGender WHERE ParentGender.Id = {0}.ParentGender) AS ParentId," +
                    "(SELECT ParentGender.Name FROM {0} AS ParentGender WHERE ParentGender.Id = {0}.ParentGender) AS ParentName," +
                    "(SELECT ParentGender.MediaType FROM {0} AS ParentGender WHERE ParentGender.Id = {0}.ParentGender) AS ParentMediaType," +
                    "(SELECT ParentGender.Status FROM {0} AS ParentGender WHERE ParentGender.Id = {0}.ParentGender) AS ParentStatus " +
                    "FROM {0} WHERE {0}.Id = {1}", this.Table, Id);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.GetRowCasted();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlConnection.Close();
            }
        }

        public List<Gender> FindAll()
        {
            try
            {
                String Query = String.Format(
                    "SELECT {0}.*," +
                    "(SELECT ParentGender.Id FROM {0} AS ParentGender WHERE ParentGender.Id = {0}.ParentGender) AS ParentId," +
                    "(SELECT ParentGender.Name FROM {0} AS ParentGender WHERE ParentGender.Id = {0}.ParentGender) AS ParentName," +
                    "(SELECT ParentGender.MediaType FROM {0} AS ParentGender WHERE ParentGender.Id = {0}.ParentGender) AS ParentMediaType," +
                    "(SELECT ParentGender.Status FROM {0} AS ParentGender WHERE ParentGender.Id = {0}.ParentGender) AS ParentStatus " +
                    "FROM {0} ORDER BY {0}.ParentGender ASC, {0}.MediaType ASC, {0}.Name ASC", this.Table);

                this.ExecSelect(Query);

                List<Gender> categories = new List<Gender>();

                while (this.SqlDataReader.Read())
                {
                    categories.Add(this.GetRowCasted());
                }

                return categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.SqlConnection.Close();
            }
        }

        private Gender GetRowCasted()
        {
            if (!this.SqlDataReader.HasRows)
                return new Gender();

            return new Gender
            {
                Id = (long) DBTransformer.GetOrDefault(this.SqlDataReader["Id"], 0),
                Name = DBTransformer.GetOrDefault(this.SqlDataReader["Name"], String.Empty),
                MediaType = new MediaTypeRepository().GetMediaType(DBTransformer.GetOrDefault(this.SqlDataReader["MediaType"], 0)),
                Status = new StatusRepository().GetStatus(DBTransformer.GetOrDefault(this.SqlDataReader["Status"], String.Empty)),
                ParentGender = this.GetParentGender()
            };
        }

        private Gender GetParentGender()
        {
            return new Gender
            {
                Id = (long) DBTransformer.GetOrDefault(this.SqlDataReader["ParentId"], 0),
                Name = DBTransformer.GetOrDefault(this.SqlDataReader["ParentName"], String.Empty),
                MediaType = new MediaTypeRepository().GetMediaType(DBTransformer.GetOrDefault(this.SqlDataReader["ParentMediaType"], 0)),
                Status = new StatusRepository().GetStatus(DBTransformer.GetOrDefault(this.SqlDataReader["ParentStatus"], String.Empty)),
            };
        }
    }
}
