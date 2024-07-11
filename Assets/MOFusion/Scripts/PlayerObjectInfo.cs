using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOFusion
{
    public class PlayerObjectInfo : MONetworkBehaviour
    {
        public void SetInstantiationData(uint[] data)
        {
            var dataInstantiation = GetComponent<IPlayerObjectInstantiated>();
            dataInstantiation.OnInstantiated(data);
        }

        protected override void OnSpawned()
        {
            Runner.SetPlayerObject(Object.StateAuthority, Object);
        }
    }
}

