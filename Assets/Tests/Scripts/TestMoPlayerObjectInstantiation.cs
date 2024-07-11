using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MOFusion.Tests
{
    public class TestMoPlayerObjectInstantiation : MonoBehaviour, IPlayerObjectInstantiated
    {
        public void OnInstantiated(uint[] data)
        {
            var instantiationData = BlittableSerializerHelper.FromDataArray<InstantiationData>(data, 0);

            GameObject graphic;

            switch (instantiationData.graphicData)
            {
                case 2:
                    {
                        graphic = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    }
                    break;
                default:
                    {
                        graphic = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    }
                    break;
            }

            graphic.transform.SetParent(transform);
        }
    }

    [StructLayout(LayoutKind.Explicit, Pack = 4)]
    public struct InstantiationData
    {
        public const int WORD_COUNT = 1;
        [FieldOffset(0)]
        public byte graphicData;
    }
}