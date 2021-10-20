namespace EasyTestFile;

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

/// <summary>
/// Exception when TestFile cannot be found.
/// </summary>
[Serializable]
public class TestFileNotFoundException : Exception
{
    internal TestFileNotFoundException(string filename, bool created)
    {
        Filename = filename;
        TestFileCreated = created;
    }

    private TestFileNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        Filename = info.GetString("Filename");
        TestFileCreated = info.GetBoolean("TestFileCreated");
    }

    /// <summary>
    /// Name of the missing filename.
    /// </summary>
    public string Filename { get; private set; }

    /// <summary>
    /// Boolean specifying if the TestFile was created. If so, the path of the filename is visible through the <seealso cref="Filename"/> property.
    /// </summary>
    public bool TestFileCreated { get; private set; }

    /// <inheritdoc />
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        if (info == null)
        {
            throw new ArgumentNullException(nameof(info));
        }

        info.AddValue("Filename", Filename);
        info.AddValue("TestFileCreated", TestFileCreated);

        base.GetObjectData(info, context);
    }
}