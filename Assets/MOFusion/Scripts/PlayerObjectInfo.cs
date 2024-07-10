using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOFusion
{
    public class PlayerObjectInfo : MONetworkBehaviour
    {
        public void SetInstantiationData(byte[] instantiationData)
        {
            Debug.Log("Set instantiate data!");
        }

        protected override void OnSpawned()
        {
            Runner.SetPlayerObject(Object.StateAuthority, Object);
            Debug.Log("A Player object has been spawned!");
        }
    }
}

