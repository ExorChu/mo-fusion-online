using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MOFusion
{
    public struct BlittableSerializerHelper
    {
        public static T FromDataArray<T>(uint[] dataArray, int wordOffset) where T : unmanaged
        {
            unsafe
            {
                fixed(uint* ptr = dataArray)
                {
                    T data = default;
                    T* dataPtr = &data;
                    *dataPtr = *(T*)(ptr + wordOffset);
                    return data;
                }
            }
        }
        
        public static void ToDataArray<T>(T data, uint[] dataArray, int wordOffset) where T : unmanaged
        {
            unsafe
            {
                int wordCount = (sizeof(T) - 1) / 4 + 1;
                Span<uint> dataArrSpan = new Span<uint>(dataArray, wordOffset, wordCount);
                Span<uint> dataSpan = new Span<uint>(&data, wordCount);
                dataSpan.CopyTo(dataArrSpan);
                //TODO: Implement faster copy since we enabled unsafe keyword already
            }            

        }
    }
}