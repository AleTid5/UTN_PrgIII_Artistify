using Common.Transformers;
using Entity.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FinalUserRepository : UserRepository
    {
        public FinalUserRepository()
        {
            this.Table = "Users_Finals";
        }

        public FinalUser FindById(int Id)
        {
            try
            {
                String Query = String.Format("SELECT TOP 1 * FROM {0} A INNER JOIN Users U ON A.Id = U.Id WHERE U.Status = 'A' AND A.Id = {1}", this.Table, Id);
                this.ExecSelect(Query);
                this.SqlDataReader.Read();

                return this.GetRowCasted(this.GetRowCasted());
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

        private FinalUser GetRowCasted(AbstractUser abstractUser)
        {
            return new FinalUser(abstractUser)
            {
                ImageSource = DBTransformer.GetOrDefault(this.SqlDataReader["ImageSource"], ""),
                Telephone = DBTransformer.GetOrDefault(this.SqlDataReader["ImageSource"], null),
                ParentUser = new FinalUser()
            };
        }
    }
}
