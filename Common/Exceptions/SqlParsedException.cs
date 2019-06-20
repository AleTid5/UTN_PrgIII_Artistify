using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class SqlParsedException : Exception
    {
        override
        public string Message { get; }

        public SqlParsedException(int code, string Message)
        {
            switch (code) {
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
