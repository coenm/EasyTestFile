namespace EasyTestFile.Internals;

/// <summary>
/// Mode how testfiles are handled during compilation.
/// </summary>
internal enum EasyTestFileMode
{
    /// <summary>
    /// Testfiles are embedded as resource. The project dll will contain the files and will be bigger. This mode is the `safest` because testfiles cannot be altered or deleted.
    /// </summary>
    Embed,

    /// <summary>
    /// Testfiles are always copied to the output directory.
    /// </summary>
    CopyAlways,

    /// <summary>
    /// Testfiles are only copied to the output directory when they are newer.
    /// </summary>
    CopyPreserveNewest,

    /// <summary>
    /// Testfiles are never copied nor are they embedded as resource. This mode speeds up compilation.
    /// </summary>
    None,
}
