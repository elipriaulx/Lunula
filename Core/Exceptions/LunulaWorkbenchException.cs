using System;

namespace Lunula.Core.Exceptions
{
    public class LunulaWorkbenchException : Exception
    {
        public LunulaWorkbenchException()
        {

        }

        public LunulaWorkbenchException(string message) : base(message)
        {

        }

        public LunulaWorkbenchException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
