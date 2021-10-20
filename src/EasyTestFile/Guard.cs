namespace EasyTestFile;

using System;
using System.IO;
using System.Linq;

internal static class Guard
{
    private static readonly char[] _invalidFileChars = Path.GetInvalidFileNameChars();
    private static readonly char[] _invalidPathChars = Path.GetInvalidPathChars()
                                                           .Concat(_invalidFileChars.Except(new[] { '/', '\\', ':' }))
                                                           .Distinct()
                                                           .ToArray();

    public static void FileExists(string path, string argumentName)
    {
        AgainstNullOrEmpty(path, argumentName);
        if (!File.Exists(path))
        {
            throw new ArgumentException($"File not found. Path: {path}", argumentName);
        }
    }
        
    public static void BadFileNameNullable(string? name, string argumentName)
    {
        if (name is null)
        {
            return;
        }

        BadFileName(name, argumentName);
    }

    public static void BadFileName(string name, string argumentName)
    {
        AgainstNullOrEmpty(name, argumentName);
        foreach (var invalidChar in _invalidFileChars)
        {
            if (name.IndexOf(invalidChar) == -1)
            {
                continue;
            }

            throw new ArgumentException($"Invalid character for file name. Value: {name}. Char:{invalidChar}", argumentName);
        }
    }

    public static void BadDirectoryName(string? name, string argumentName)
    {
        if (name is null)
        {
            return;
        }

        AgainstEmpty(name, argumentName);
        foreach (var invalidChar in _invalidPathChars)
        {
            if (name.IndexOf(invalidChar) == -1)
            {
                continue;
            }

            throw new ArgumentException($"Invalid character for directory. Value: {name}. Char:{invalidChar}", argumentName);
        }
    }

    public static void AgainstNullOrEmpty(string value, string argumentName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(argumentName);
        }
    }

    public static void AgainstEmpty(string? value, string argumentName)
    {
        if (value is null)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(argumentName);
        }
    }

    public static void AgainstNullOrEmpty(object?[] value, string argumentName)
    {
        if (value is null)
        {
            throw new ArgumentNullException(argumentName);
        }

        if (value.Length == 0)
        {
            throw new ArgumentNullException(argumentName, "Argument cannot be empty.");
        }
    }

    public static void AgainstNullOrEmpty<T>(T[] value, string argumentName)
    {
        if (value is null)
        {
            throw new ArgumentNullException(argumentName);
        }

        if (value.Length == 0)
        {
            throw new ArgumentNullException(argumentName, "Argument cannot be empty.");
        }
    }

    public static void AgainstBadExtension(string value, string argumentName)
    {
        AgainstNullOrEmpty(value, argumentName);

        if (value.StartsWith("."))
        {
            throw new ArgumentException("Must not start with a period ('.').", argumentName);
        }
    }
}