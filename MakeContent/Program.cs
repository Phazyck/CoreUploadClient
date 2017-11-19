using System;
using System.IO;

namespace MakeContent
{
    class Program
    {
        static int WriteError()
        {
            Console.Error.WriteLine("usage: TODO");
            return -1;
        }

        static int Main(string[] args)
        {
            if (args == null || args.Length <= 0)
            {
                return WriteError();
            }
            
            if (!ulong.TryParse(args[0], out ulong length))
            {
                return WriteError();
            }

            Stream stream = Console.OpenStandardOutput();
            const int bufferSize = 1024 * 1024;
            byte[] buffer = new byte[bufferSize];

            int bufferIndex = 0;
            void Write(char c)
            {
                buffer[bufferIndex++] = (byte)c;
                if (bufferIndex >= buffer.Length)
                {
                    bufferIndex = 0;
                    stream.Write(buffer, 0, buffer.Length);
                    stream.Flush();
                }
            }

            void Close()
            {
                if (bufferIndex > 0)
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
                stream.Close();
            }
            
            {
                char c = 'a';

                for (ulong i = 0; i < length; ++i)
                {

                    Write(c);

                    if (++c > 'z')
                    {
                        c = 'a';
                    }
                }
            }
            Close();

            return 0;
        }
    }
}
