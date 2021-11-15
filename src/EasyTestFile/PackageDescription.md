# EasyTestFile

EasyTestFile is a library that simplifies the creation and usage of testfiles in unittests. 
Testfiles (like text, json, xml, binary, jpg, etc. etc.) are named based on the class and method name, are created if not exist, and are embedded as resource making sure the execution of the test is deterministic and do not rely on untracked files etc.

This package contains EasyTestFile framework independent logic. You should also refrence [EasyTestFile.XUnit](https://www.nuget.org/packages/EasyTestFile.XUnit/) or [EasyTestFile.NUnit](https://www.nuget.org/packages/EasyTestFile.NUnit/) depending on your test framwork.
