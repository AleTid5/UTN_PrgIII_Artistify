using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class SqlParsedException : Exception
    {
        override
        public string Message { get; }

        public SqlParsedException(int code, string Message = null)
        {
            switch (code) {
                case 100:
                    this.Message = "No se han encontrado registros.";
                    break;
                case 2601:
                    this.Message = "Ya existe un registro con la información brindada.";
                    break;
                default:
                    this.Message = Message;
                    break;
            }
        }
    }
}
