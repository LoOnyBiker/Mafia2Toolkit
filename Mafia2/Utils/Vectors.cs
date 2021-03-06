﻿using System;
using System.ComponentModel;
using System.IO;

namespace Mafia2
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Vector3
    {
        private float x;
        private float y;
        private float z;

        public float X
        {
            get { return x;}
            set { x = value; }
        }
        public float Y {
            get { return y; }
            set { y = value; }
        }
        public float Z {
            get { return z; }
            set { z = value; }
        }

        /// <summary>
        /// Construct a Vector3 from three floats.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Construct a Vector3 and set all three values to the passed value.
        /// </summary>
        /// <param name="value"></param>
        public Vector3(float value)
        {
            this.x = value;
            this.y = value;
            this.z = value;
        }

        /// <summary>
        /// Copy from passing vector.
        /// </summary>
        /// <param name="vector"></param>
        public Vector3(Vector3 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
        }

        /// <summary>
        /// Construct Vector3 from file data.
        /// </summary>
        /// <param name="reader"></param>
        public Vector3(BinaryReader reader)
        {
            x = y = z = 0;
            ReadfromFile(reader);
        }

        /// <summary>
        /// Write vector3 to file.
        /// </summary>
        /// <param name="writer"></param>
        public void WriteToFile(BinaryWriter writer)
        {
            writer.Write(x);
            writer.Write(y);
            writer.Write(z);
        }

        /// <summary>
        /// Read Vector3 data from file.
        /// </summary>
        /// <param name="reader"></param>
        public void ReadfromFile(BinaryReader reader)
        {
            x = reader.ReadSingle();
            y = reader.ReadSingle();
            z = reader.ReadSingle();
        }

        /// <summary>
        /// Convert vector3 radians to degrees.
        /// </summary>
        public void ConvertToDegrees()
        {
            x = -(float)(X * 180 / Math.PI);
            y = -(float)(Y * 180 / Math.PI);
            z = -(float)(Z * 180 / Math.PI);
        }

        /// <summary>
        /// Convert vector3 degrees to radians
        /// </summary>
        public void ConvertToRadians()
        {
            x = -(float)(X * Math.PI / 180);
            y = -(float)(Y * Math.PI / 180);
            z = -(float)(Z * Math.PI / 180);
        }

        /// <summary>
        /// Find the cross product between two vectors.
        /// </summary>
        /// <param name="vector2"></param>
        public void CrossProduct(Vector3 vector2)
        {
            X = Y * vector2.Z - Z * vector2.Y;
            Y = Z * vector2.X - X * vector2.Z;
            Z = X * vector2.Y - Y * vector2.X;
        }

        /// <summary>
        /// Returns the Dot Product of two vectors.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public float DotProduct(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.x * rhs.x) + (lhs.y * rhs.y) + (lhs.z * rhs.z);
        }

        /// <summary>
        /// Normalize the vector3.
        /// </summary>
        public void Normalize()
        {
            float num1 = (float)(X * (double)X + Y * Y + Z * (double)Z);
            float num2 = num1 == 0.0 ? float.MaxValue : (float)(1.0 / Math.Sqrt(num1));
            X *= num2;
            Y *= num2;
            Z *= num2;
        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            Vector3 vec = new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
            return (float)Math.Sqrt(vec.x * vec.x + vec.y * vec.y + vec.z * vec.z);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector3 operator *(Vector3 a, float scale)
        {
            return new Vector3(a.X * scale, a.Y * scale, a.Z * scale);
        }
        public static Vector3 operator /(Vector3 a, float scale)
        {
            return new Vector3(a.X / scale, a.Y / scale, a.Z / scale);
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}";
        }

    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        /// <summary>
        /// Construct Vector2 from two floats.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Construct Vector2 from file data.
        /// </summary>
        /// <param name="reader"></param>
        public Vector2(BinaryReader reader)
        {
            ReadFromFile(reader);
        }

        public void ReadFromFile(BinaryReader reader)
        {
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
        }

        public void WriteToFile(BinaryWriter writer)
        {
            writer.Write(X);
            writer.Write(Y);
        }

        /// <summary>
        /// Returns the Dot Product of two vectors.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static float DotProduct(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Float4
    {
        public float[] Data { get; set; }

        /// <summary>
        /// Construct Float4 from parsed data.
        /// </summary>
        /// <param name="reader"></param>
        public Float4(BinaryReader reader)
        {
            ReadFromFile(reader);
        }

        public Float4()
        {
            Data = new float[4];
        }

        /// <summary>
        /// Read data from file.
        /// </summary>
        /// <param name="reader"></param>
        public void ReadFromFile(BinaryReader reader)
        {
            Data = new float[4];

            for (int i = 0; i != 4; i++)
                Data[i] = reader.ReadSingle();
        }

        /// <summary>
        /// Write data to file.
        /// </summary>
        /// <param name="writer"></param>
        public void WriteToFile(BinaryWriter writer)
        {
            for (int i = 0; i != 4; i++)
                writer.Write(Data[i]);
        }

        public override string ToString()
        {
            return $"{Data[0]}, {Data[1]}, {Data[2]}, {Data[3]}";
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class UVVector2
    {
        public Half X { get; set; }
        public Half Y { get; set; }

        /// <summary>
        /// Construct UV Vector from two halfs.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public UVVector2(Half x, Half y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Construct empty vector
        /// </summary>
        public UVVector2()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Write UVVector2 as floats.
        /// </summary>
        public void WriteToFile(BinaryWriter writer)
        {       
            writer.Write(HalfHelper.HalfToSingle(X));
            writer.Write(HalfHelper.HalfToSingle(Y));
           // writer.Write((Half)1f-Y);
        }

        /// <summary>
        /// Read UVVector2 from file as floats.
        /// </summary>
        /// <param name="reader"></param>
        public void ReadFromFile(BinaryReader reader)
        {
            X = HalfHelper.SingleToHalf(reader.ReadSingle());
            Y = HalfHelper.SingleToHalf(reader.ReadSingle());
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }

    public class Short3
    {
        public ushort S1 { get; set; }
        public ushort S2 { get; set; }
        public ushort S3 { get; set; }

        /// <summary>
        /// SET all values to -100
        /// </summary>
        public Short3()
        {
            S1 = ushort.MaxValue;
            S2 = ushort.MaxValue;
            S3 = ushort.MaxValue;
        }

        /// <summary>
        /// Construct Short3 from file data.
        /// </summary>
        /// <param name="reader"></param>
        public Short3(BinaryReader reader)
        {
            S1 = reader.ReadUInt16();
            S2 = reader.ReadUInt16();
            S3 = reader.ReadUInt16();
        }

        /// <summary>
        /// Build Short3 from Int3
        /// </summary>
        /// <param name="ints"></param>
        public Short3(Int3 ints)
        {
            S1 = (ushort)ints.I1;
            S2 = (ushort)ints.I2;
            S3 = (ushort)ints.I3;
        }

        /// <summary>
        /// Construct Short3 from three integers.
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <param name="i3"></param>
        public Short3(int i1, int i2, int i3)
        {
            S1 = (ushort)i1;
            S2 = (ushort)i2;
            S3 = (ushort)i3;
        }

        /// <summary>
        /// Write Short3 data to file.
        /// </summary>
        /// <param name="writer"></param>
        public void WriteToFile(BinaryWriter writer)
        {
            writer.Write(S1);
            writer.Write(S2);
            writer.Write(S3);
        }

        public override string ToString()
        {
            return $"{S1} {S2} {S3}";
        }
    }

    public class Int3
    {
        public int I1 { get; set; }
        public int I2 { get; set; }
        public int I3 { get; set; }

        /// <summary>
        /// Construct Int3 from file data.
        /// </summary>
        /// <param name="reader"></param>
        public Int3(BinaryReader reader)
        {
            ReadFromFile(reader);
        }

        /// <summary>
        /// Build Int3 from Short3
        /// </summary>
        /// <param name="ints"></param>
        public Int3(Short3 s3)
        {
            I1 = (int)s3.S1;
            I2 = (int)s3.S2;
            I3 = (int)s3.S3;
        }

        /// <summary>
        /// read data from file.
        /// </summary>
        /// <param name="reader"></param>
        public void ReadFromFile(BinaryReader reader)
        {
            I1 = reader.ReadInt32();
            I2 = reader.ReadInt32();
            I3 = reader.ReadInt32();
        }

        /// <summary>
        /// write data to file
        /// </summary>
        /// <param name="writer"></param>
        public void WriteToFile(BinaryWriter writer)
        {
            writer.Write(I1);
            writer.Write(I2);
            writer.Write(I3);
        }

        public override string ToString()
        {
            return $"{I1} {I2} {I3}";
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Polygon
    {
        int numPoints;
        int firstVertIndex;
        int firstUnkIndex;
        Vector3 normal;
        float[] floats;

        public int NumPoints {
            get { return numPoints; }
            set { numPoints = value; }
        }
        public int FirstVertIndex {
            get { return firstVertIndex; }
            set { firstVertIndex = value; }
        }
        public int FirstUnkIndex {
            get { return firstUnkIndex; }
            set { firstUnkIndex = value; }
        }
        public Vector3 Normal {
            get { return normal; }
            set { normal = value; }
        }
        public float[] Floats {
            get { return floats; }
            set { floats = value; }
        }

        public Polygon(BinaryReader reader)
        {
            numPoints = reader.ReadInt32();
            firstVertIndex = reader.ReadInt32();
            firstUnkIndex = reader.ReadInt32();
            normal = new Vector3(reader);
            floats = new float[]{ reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle() };
        }
    }
}
