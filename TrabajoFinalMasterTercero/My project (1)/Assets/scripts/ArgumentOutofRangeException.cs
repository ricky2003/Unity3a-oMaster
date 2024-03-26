using System;
using System.Runtime.Serialization;

[Serializable]
internal class ArgumentOutofRangeException : Exception
{
    private string v;
    private GameState newState;
    private object p;

    public ArgumentOutofRangeException()
    {
    }

    public ArgumentOutofRangeException(string message) : base(message)
    {
    }

    public ArgumentOutofRangeException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ArgumentOutofRangeException(string v, GameState newState, object p)
    {
        this.v = v;
        this.newState = newState;
        this.p = p;
    }

    protected ArgumentOutofRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}