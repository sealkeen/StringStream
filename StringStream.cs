﻿//Source URL: https://stackoverflow.com/a/51957925/6897369
//Author URL: https://stackoverflow.com/users/7422838/aquirky

using System;
using System.IO;
using System.Text;

namespace Utility.StringStream
{
    public class StringStream : Stream
    {
        private readonly MemoryStream _memory;
        public StringStream(string text)
        {                               //UTF8
            _memory = new MemoryStream(Encoding.Default.GetBytes(text));
        }
        public StringStream()
        {
            _memory = new MemoryStream();
        }
        public StringStream(int capacity)
        {
            _memory = new MemoryStream(capacity);
        }
        public override void Flush()
        {
            _memory.Flush();
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return _memory.Read(buffer, offset, count);
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return _memory.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            _memory.SetLength(value);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            _memory.Write(buffer, offset, count);
        }
        public override bool CanRead => _memory.CanRead;
        public override bool CanSeek => _memory.CanSeek;
        public override bool CanWrite => _memory.CanWrite;
        public override long Length => _memory.Length;
        public override long Position
        {
            get => _memory.Position;
            set => _memory.Position = value;
        }
        public override string ToString()
        {
            return System.Text.Encoding.UTF8.GetString(_memory.GetBuffer(), 0, (int)_memory.Length);
        }
        public override int ReadByte()
        {
            return _memory.ReadByte();
        }
        public override void WriteByte(byte value)
        {
            _memory.WriteByte(value);
        }
    }
}
