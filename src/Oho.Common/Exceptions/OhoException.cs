using System;

namespace Oho.Common.Exceptions
{
    public class OhoException : Exception
    {
        public string Code {get;}

        public OhoException()
        {}

        public OhoException(string code)
        {
            this.Code=code;
        }

        public OhoException(string message, params object[] args)
        :   this(string.Empty, message, args)
        {
            
        }

        public OhoException( string code, string message, params object[] args)
        :   this(null, code, message, args)
        {
            
        }

        public OhoException(Exception innerException, string message, params object[] args)
        :  this(innerException, string.Empty, message, args)
        {

        }

        public OhoException(Exception innerException, string code, string message, params object[] args)
        :    base(string.Format(message, args), innerException)
        {
            this.Code = Code;
        }
}
}