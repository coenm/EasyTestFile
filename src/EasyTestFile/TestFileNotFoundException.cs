namespace EasyTestFile
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class TestFileNotFoundException : Exception
    {
        public TestFileNotFoundException(string filename, bool created)
        {
            Filename = filename;
            TestFileCreated = created;
        }


        public string Filename { get; private set; }

        public bool TestFileCreated { get; private set; }
        
        private TestFileNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Filename = info.GetString("Filename");
            TestFileCreated = info.GetBoolean("TestFileCreated");
        }

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
}
