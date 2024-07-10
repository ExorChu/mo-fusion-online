using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOFusion
{
    public class MONetworkBehaviour : NetworkBehaviour
    {
        public GameManager GameManager { get; private set; }

        public sealed override void Spawned()
        {
            GameManager = Runner.GetBehaviour<GameManager>();
            OnSpawned();
        }        

        public sealed override void Despawned(NetworkRunner runner, bool hasState)
        {
            OnDespawned(runner, hasState);
        }

        protected virtual void OnSpawned()
        {

        }

        protected virtual void OnDespawned(NetworkRunner runner, bool hasState)
        {

        }
    }

}
