namespace RoleWebApi.Infrastructure.CrossCutting.Exceptions.Domain
{
    using System;

    [Serializable]
    public class DominioException : Exception
    {
        public DominioException() { }
        public DominioException(string message) : base(message) { }
        public DominioException(string message, Exception inner) : base(message, inner) { }
        protected DominioException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
