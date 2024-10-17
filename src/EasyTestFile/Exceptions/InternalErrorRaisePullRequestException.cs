// ReSharper disable once CheckNamespace
namespace EasyTestFile;

using System;
using System.Runtime.Serialization;

/// <summary>
/// Exception when an internal error happens.
/// </summary>
public sealed class InternalErrorRaisePullRequestException : Exception
{
    /// <summary>
    /// Exception when an internal error happens.
    /// </summary>
    internal InternalErrorRaisePullRequestException(string message) 
        : base(message + " Raise a Pull Request with a test that replicates this problem.")
    {
    }
}