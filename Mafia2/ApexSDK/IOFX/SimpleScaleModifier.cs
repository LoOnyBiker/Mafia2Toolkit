﻿using Mafia2;
using System;
using System.IO;

namespace ApexSDK
{
    public class SimpleScaleModifier : Modifier
    {
        private Vector3 scaleFactor;

        public Vector3 ScaleFactor {
            get { return scaleFactor; }
            set { scaleFactor = value; }
        }

        public SimpleScaleModifier()
        {
            Type = ModifierType.ModifierType_SimpleScale;
        }

        public SimpleScaleModifier(BinaryReader reader)
        {
            ReadFromFile(reader);
            Type = ModifierType.ModifierType_SimpleScale;
        }

        public override void ReadFromFile(BinaryReader reader)
        {
            scaleFactor = new Vector3(reader);
        }

        public override void WriteToFile(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("ScaleFactor: {0}", scaleFactor);
        }
    }
}
