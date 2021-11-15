# EasyTestFile

EasyTestFile is a library that simplifies the creation and usage of testfiles in unittests. 
Testfiles (like text, json, xml, binary, jpg, etc. etc.) are named based on the class and method name, are created if not exist, and are embedded as resource making sure the execution of the test is deterministic and do not rely on untracked files etc.

# EasyTestFile.Nunit

This package is required when your project uses NUnit for unittesting. No setup is required.

## Samples

<!-- snippet: NunitLoadAsText -->
<!-- endSnippet -->

<!-- snippet: NunitLoadAsStream -->
<!-- endSnippet -->

Or load the TestFile object first

<!-- snippet: NunitLoadAsTestFileBasic -->
<!-- endSnippet -->

