namespace EasyTestFile;

using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

internal static class Guard
{
    private static readonly char[] _invalidFileChars = Path.GetInvalidFileNameChars();
    private static readonly char[] _invalidPathChars = Path.GetInvalidPathChars()
                                                           .Concat(_invalidFileChars.Except(new[] { '/', '\\', ':', }))
                                                           .Distinct()
                                                           .ToArray();
    
    public static void BadFileName(string name, string argumentName)
    {
        AgainstNullOrEmpty(name, argumentName);
        foreach (var invalidChar in _invalidFileChars)
        {
            if (!name.Contains(invalidChar))
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
            if (!name.Contains(invalidChar))
            {
                continue;
            }

            throw new ArgumentException($"Invalid character for directory. Value: {name}. Char:{invalidChar}", argumentName);
        }
    }

    private static void AgainstNullOrEmpty(string value, string argumentName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(argumentName);
        }
    }

    private static void AgainstEmpty(string? value, string argumentName)
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

    public static void AgainstBadExtension(string value, string argumentName)
    {
        AgainstNullOrEmpty(value, argumentName);

        if (value.StartsWith("."))
        {
            throw new ArgumentException("Must not start with a period ('.').", argumentName);
        }
    }

    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> contains an invalid character.</exception>
    public static void AgainstBadMethodName(string value, string argumentName)
    {
        AgainstNullOrEmpty(value, argumentName);

        var invalidChar = ' ';
        if (value[0] == invalidChar)
        {
            throw new ArgumentException($"Value: {value} starts with an invalid character (space)", argumentName);
        }

        if (value[value.Length - 1] == invalidChar)
        {
            throw new ArgumentException($"Value: {value} ends with an invalid character (space)", argumentName);
        }

        invalidChar = '\\';
        if (value.Contains(invalidChar))
        {
            throw new ArgumentException($"Value: {value} contains an invalid character ('{invalidChar}')", argumentName);
        }

        invalidChar = '/';
        if (value.Contains(invalidChar))
        {
            throw new ArgumentException($"Value: {value} contains an invalid character ('{invalidChar}')", argumentName);
        }
    }
}
