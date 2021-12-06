namespace EasyTestFile;

using System;
using System.Runtime.Serialization;

/// <summary>
/// Exception when an internal error happens.
/// </summary>
[Serializable]
public sealed class InternalErrorRaisePullRequestException : Exception
{
    /// <summary>
    /// Exception when an internal error happens.
    /// </summary>
    internal InternalErrorRaisePullRequestException(string message) 
        : base(message + " Raise a Pull Request with a test that replicates this problem.")
    {
    }

    private InternalErrorRaisePullRequestException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    /// <inheritdoc />
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }
}