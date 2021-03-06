﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Mafia2
{
    public class Vertex
    {
        Vector3 position;
        Vector3 normal;
        Vector3 tangent;
        Vector3 binormal;
        float blendWeight;
        int boneID;
        UVVector2[] uvs;
        int damageGroup;

        public Vector3 Position {
            get { return position; }
            set { position = value; }
        }
        public Vector3 Normal {
            get { return normal; }
            set { normal = value; }
        }
        public Vector3 Tangent {
            get { return tangent; }
            set { tangent = value; }
        }
        public Vector3 Binormal {
            get { return binormal; }
            set { binormal = value; }
        }
        public UVVector2[] UVs {
            get { return uvs; }
            set { uvs = value; }
        }
        public float BlendWeight {
            get { return blendWeight; }
            set { blendWeight = value; }
        }
        public int BoneID {
            get { return boneID; }
            set { boneID = value; }
        }
        public int DamageGroup {
            get { return damageGroup; }
            set { damageGroup = value; }
        }

        /// <summary>
        /// Construct empty vertex.
        /// </summary>
        public Vertex()
        {
            position = new Vector3(0);
            normal = new Vector3(0);
            tangent = new Vector3(0);
            uvs = new UVVector2[4];

            for (int i = 0; i != uvs.Length; i++)
                uvs[i] = new UVVector2();
        }

        /// <summary>
        /// Read position data using buffer data, datapos, decompFactor and the decompOffset
        /// </summary>
        /// <param name="data">vertex buffer data</param>
        /// <param name="i">current position to read from</param>
        /// <param name="factor">Decompression Factor</param>
        /// <param name="offset">Decompression Offset</param>
        public void ReadPositionData(byte[] data, int i, float factor, Vector3 offset)
        {
            ushort x = BitConverter.ToUInt16(data, i);
            ushort y = BitConverter.ToUInt16(data, i + 2);
            ushort z = (ushort)(BitConverter.ToUInt16(data, i + 4) & short.MaxValue);
            position = new Vector3(x * factor, y * factor, z * factor);
            position += offset;         
        }

        /// <summary>
        /// Write position data into buffer. Uses Decompression factor, and offset.
        /// </summary>
        /// <param name="factor"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public void WritePositionData(byte[] data, int i, float factor, Vector3 offset)
        {
            position -= offset;
            position /= factor;
            byte[] tempPosData;

            //Do X
            tempPosData = BitConverter.GetBytes(Convert.ToUInt16(position.X));
            Array.Copy(tempPosData, 0, data, i, 2);

            //Do Y
            tempPosData = BitConverter.GetBytes(Convert.ToUInt16(position.Y));
            Array.Copy(tempPosData, 0, data, i+2, 2);

            //Do Z
            tempPosData = BitConverter.GetBytes(Convert.ToUInt16(position.Z));
            Array.Copy(tempPosData, 0, data, i+4, 2);

            data[i + 6] = 0x27;
            data[i + 7] = 0xDB;
        }

        /// <summary>
        /// Read tangent data from buffer data, datapos.
        /// </summary>
        /// <param name="data">vertex buffer data</param>
        /// <param name="i">current position to read from</param>
        public void ReadTangentData(byte[] data, int i)
        {
            float x = (data[i + 6] - sbyte.MaxValue) * 0.007874f;
            float y = (data[i + 7] - sbyte.MaxValue) * 0.007874f;
            float z = (data[i + 11] - sbyte.MaxValue) * 0.007874f;
            tangent = new Vector3(x, y, z);
            tangent.Normalize();
        }

        /// <summary>
        /// Write tangent data from buffer.
        /// </summary>
        /// <returns></returns>
        public void WriteTangentData(byte[] data, int i)
        {
            byte tempByte = 0;
            float tempNormal = 0f;

            //X..
            tempNormal = Tangent.X * 127.0f + 127.0f;
            tempByte = !float.IsNaN(tempNormal) ? Convert.ToByte(tempNormal) : (byte)127;
            data[i + 6] = tempByte;

            //Y..
            tempNormal = Tangent.Y * 127.0f + 127.0f;
            tempByte = !float.IsNaN(tempNormal) ? Convert.ToByte(tempNormal) : (byte)127;
            data[i + 7] = tempByte;

            //Z..
            tempNormal = Tangent.Z * 127.0f + 127.0f;
            tempByte = !float.IsNaN(tempNormal) ? Convert.ToByte(tempNormal) : (byte)255;
            data[i + 11] = tempByte;
        }

        /// <summary>
        /// Read normal data from buffer data, datapos.
        /// </summary>
        /// <param name="data">vertex buffer data</param>
        /// <param name="i">current position to read from</param>
        public void ReadNormalData(byte[] data, int i)
        {
            float x = (data[i] - 127.0f) * 0.007874f;
            float y = (data[i + 1] - 127.0f) * 0.007874f;
            float z = (data[i + 2] - 127.0f) * 0.007874f;
            normal = new Vector3(x, y, z);
            normal.Normalize();
        }

        /// <summary>
        /// Write tangent data from buffer.
        /// </summary>
        /// <returns></returns>
        public void WriteNormalData(byte[] data, int i)
        {
            byte tempByte = 0;
            float tempNormal = 0f;

            //X..
            tempNormal = Normal.X * 127.0f + 127.0f;
            tempByte = !float.IsNaN(tempNormal) ? Convert.ToByte(tempNormal) : (byte)127;
            data[i] = tempByte;

            //Y..
            tempNormal = Normal.Y * 127.0f + 127.0f;
            tempByte = !float.IsNaN(tempNormal) ? Convert.ToByte(tempNormal) : (byte)127;
            data[i + 1] = tempByte;

            //Z..
            tempNormal = Normal.Z * 127.0f + 127.0f;
            tempByte = !float.IsNaN(tempNormal) ? Convert.ToByte(tempNormal) : (byte)255;
            data[i + 2] = tempByte;
        }

        /// <summary>
        /// This is WIP.
        /// </summary>
        /// <param name="data">vertex buffer data</param>
        /// <param name="i">current position to read from</param>
        public void ReadBlendData(byte[] data, int i)
        {
            //todo; work on skeleton models.
            blendWeight = (BitConverter.ToSingle(data, i) / byte.MaxValue);
            boneID = BitConverter.ToInt32(data, i + 4);
        }

        /// <summary>
        /// Read UV data from buffer data, datapos, and numuvs.
        /// </summary>
        /// <param name="data">vertex buffer data</param>
        /// <param name="i">current position to read from</param>
        /// <param name="uvpos">numuvs</param>
        public void ReadUvData(byte[] data, int i, int uvpos)
        {
            Half x = Half.ToHalf(data, i);
            Half y = Half.ToHalf(data, i + 2);
            y = -y;
            uvs[uvpos] = new UVVector2(x, y);
        }

        /// <summary>
        /// Write UV Data to buffer. uvNum is either TexCoord 0, 1, 2, 7
        /// </summary>
        /// <param name="uvNum"></param>
        /// <returns></returns>
        public void WriteUvData(byte[] data, int i, int uvNum)
        {
            byte[] tempPosData;

            //Do X
            tempPosData = Half.GetBytes(UVs[uvNum].X);
            Array.Copy(tempPosData, 0, data, i, 2);

            //Do Y
            UVs[uvNum].Y = -uvs[uvNum].Y;
            tempPosData = Half.GetBytes(UVs[uvNum].Y);
            Array.Copy(tempPosData, 0, data, i + 2, 2);
        }

        /// <summary>
        /// Write Damage group to buffer
        /// </summary>
        /// <param name="uvNum"></param>
        /// <returns></returns>
        public void WriteDamageGroup(byte[] data, int i)
        {
            byte[] tempDamageIDData = BitConverter.GetBytes(damageGroup);
            Array.Copy(tempDamageIDData, 0, data, i, 4);
        }

        /// <summary>
        /// Read Damage Group from buffer
        /// </summary>
        /// <param name="data">vertex buffer data</param>
        /// <param name="i">current position to read from</param>
        public void ReadDamageGroup(byte[] data, int i)
        {
            //todo; work on skeleton models.
            damageGroup = BitConverter.ToInt32(data, i);
            Console.WriteLine(damageGroup);
        }

        /// <summary>
        /// Construct binormal data from normal and tangent info.
        /// </summary>
        public void BuildBinormals()
        {
            binormal = normal;
            binormal.CrossProduct(tangent);
            binormal *= 2;
            binormal.Normalize();
        }

        public override string ToString()
        {
            return string.Format(position.ToString());
        }
    }
}
