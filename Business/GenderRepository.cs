using Domain;
using System;
using System.Collections.Generic;

namespace Business
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
                String Query = String.Format("SELECT TOP 1 * FROM {0} WHERE Id = {1}", this.Table, Id);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.GetGender();
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
                String Query = String.Format("SELECT * FROM {0} ORDER BY Status ASC, Name ASC", this.Table);
                this.ExecSelect(Query);

                List<Gender> categories = new List<Gender>();

                while (this.SqlDataReader.Read())
                {
                    Gender gender = this.GetGender();
                    categories.Add(gender);
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

        private Gender GetGender()
        {
            return new Gender
            {
                Id = int.Parse(this.SqlDataReader["Id"].ToString()),
                Name = this.SqlDataReader["Name"].ToString(),
                MediaType = (new MediaTypeRepository()).GetMediaType(int.Parse(this.SqlDataReader["MediaType"].ToString())),
                Status = (new StatusRepository()).GetStatus(this.SqlDataReader["Status"].ToString()),
                // ParentGender = (new GenderRepository()).GetGender(int.Parse(this.SqlDataReader["ParentGender"].ToString()))
            };
        }
    }
}
