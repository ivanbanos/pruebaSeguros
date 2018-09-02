using System;
using System.Runtime.Serialization;

namespace InsurranceLogic.ModelAdapter
{
    [Serializable]
    internal class ModeloNoExisteException : Exception
    {
        public ModeloNoExisteException()
        {
        }

        public ModeloNoExisteException(string message) : base(message)
        {
        }

        public ModeloNoExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModeloNoExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}