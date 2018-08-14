using System;
using System.Runtime.Serialization;

namespace ZombieGame
{
    [Serializable]
    internal class IllegialStateException : Exception
    {
        public IllegialStateException()
        {
        }

        public IllegialStateException(string message) : base(message)
        {
        }

        public IllegialStateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IllegialStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}