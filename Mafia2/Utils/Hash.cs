﻿using Gibbed.Illusion.FileFormats.Hashing;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Mafia2
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Hash
    {
        ulong hash;
        string _hex;
        string _string;
        short size;

        [ReadOnly(true)]
        public ulong uHash {
            get { return hash; }
            set { hash = value; }
        }
        public string String {
            get { return _string; }
            set { Set(value); }
        }

        [ReadOnly(true)]
        public string Hex {
            get { return _hex; }
        }
        public Hash()
        {
            _string = "";
            hash = 0;
        }
        public Hash(string name)
        {
            Set(name);
        }
        public Hash(BinaryReader reader)
        {
            ReadFromFile(reader);
        }

        /// <summary>
        /// read name from file.
        /// </summary>
        /// <param name="reader"></param>
        public void ReadFromFile(BinaryReader reader)
        {
            hash = reader.ReadUInt64();
            size = reader.ReadInt16();
            _string = Encoding.ASCII.GetString(reader.ReadBytes(size));
            _hex = string.Format("{0:X8}", hash);
        }

        /// <summary>
        /// save hash to file.
        /// </summary>
        /// <param name="writer"></param>
        public void WriteToFile(BinaryWriter writer)
        {
            writer.Write(hash);
            writer.Write(size);
            writer.Write(_string.ToCharArray());
        }

        /// <summary>
        /// Sets hash name and updates hash automatically.
        /// </summary>
        /// <param name="name"></param>
        public void Set(string name)
        {
            _string = name;
            size = (short)name.Length;
            hash = FNV64.Hash(name);
            _hex = string.Format("{0:X}", hash);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_string))
                return ((SkeletonBoneIDs)hash).ToString();
            else
                return _string;
        }
    }
}
