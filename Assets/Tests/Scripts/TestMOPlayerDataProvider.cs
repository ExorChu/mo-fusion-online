using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOFusion.Tests
{
    public class TestMOPlayerDataProvider : MonoBehaviour, IPlayerObjectDataProvider
    {
        public void ProvideData(PlayerRef playerRef, Action<PlayerRef, uint[]> callback)
        {
            InstantiationData data = new InstantiationData();
            data.graphicData = 2;

            uint[] dataArray = new uint[InstantiationData.WORD_COUNT];
            BlittableSerializerHelper.ToDataArray(data, dataArray, 0);
            callback.Invoke(playerRef, dataArray);
        }

        [ContextMenu("Test convert Instantiation data")]
        private void TestConvertInstantiationData()
        {
            InstantiationData data = new InstantiationData();
            data.graphicData = 155;

            uint[] dataArr = new uint[1];

            BlittableSerializerHelper.ToDataArray(data, dataArr, 0);
            //InstantiationData.ToDataArray2(data, dataArr, 0);


            //InstantiationData revert = InstantiationData.FromDataArray(dataArr, 0);
            InstantiationData revert = BlittableSerializerHelper.FromDataArray<InstantiationData>(dataArr, 0);

            Debug.Log(revert.graphicData);
        }
    }
}

