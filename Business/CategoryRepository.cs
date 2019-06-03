using Entity;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class CategoryRepository : Repository
    {
        public CategoryRepository()
        {
            this.Table = "Categories";
        }

        public void AddCategory(Category category)
        {
            try
            {
                String QueryTemplate = "INSERT INTO {0} (Name, BlockedAge) VALUES ('{1}', {2})";
                String Query = String.Format(QueryTemplate, this.Table, category.Name, category.BlockedAge);
                this.ExecInsert(Query);
            } catch (Exception ex)
            {
                throw ex;
            } finally
            {
                this.SqlConnection.Close();
            }
        }

        public void EditCategory(Category category)
        {
            try
            {
                String QueryTemplate = "UPDATE {0} SET Name = '{1}', BlockedAge = {2} , Status = '{3}' WHERE Id = {4}";
                String Query = String.Format(QueryTemplate, this.Table, category.Name, category.BlockedAge, category.Status.Code, category.Id);
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

        public void RemoveCategory(Category category)
        {
            try
            {
                String QueryTemplate = "UPDATE {0} SET Status = 'B' WHERE Id = {1}";
                String Query = String.Format(QueryTemplate, this.Table, category.Id);
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

        public List<Category> FindAll()
        {
            try
            {
                String Query = String.Format("SELECT * FROM {0} ORDER BY Status ASC, Name ASC", this.Table);
                this.ExecSelect(Query);

                List<Category> categories = new List<Category>();

                while (this.SqlDataReader.Read())
                {
                    Category category = this.GetCategory();
                    categories.Add(category);
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

        private Category GetCategory()
        {
            return new Category
            {
                Id = int.Parse(this.SqlDataReader["Id"].ToString()),
                Name = this.SqlDataReader["Name"].ToString(),
                BlockedAge = int.Parse(this.SqlDataReader["BlockedAge"].ToString()),
                Status = (new StatusRepository()).GetStatus(this.SqlDataReader["Status"].ToString())
            };
        }
    }
}
