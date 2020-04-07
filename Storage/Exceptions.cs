namespace thefirst.Storage
{
    [System.Serializable]
    public class IncorrectModelDataException : System.Exception //
    {
        public IncorrectModelDataException() { }
        public IncorrectModelDataException(string message) : base(message) { }
        public IncorrectModelDataException(string message, System.Exception inner) : base(message, inner) { }
        protected IncorrectModelDataException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}