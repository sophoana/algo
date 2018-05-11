using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Challenges
{
    public interface ICloningService
    {
        T Clone<T>(T source);
    }

    public class CloningService : ICloningService
    {
        public T Clone<T>(T source)
        {
            throw new NotImplementedException();
        }

        public T CloneT<T> (T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        // Feel free to add any other methods, classes, etc.
    }
}
