using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOFusion
{
    public class StateAuthorityChangeDetection : NetworkBehaviour, IStateAuthorityChanged
    {
        public event System.Action<bool> OnAuthorityChanged;
        private bool hasAuthority;

        public override void Spawned()
        {
            hasAuthority = Object.HasStateAuthority;
        }

        public void StateAuthorityChanged()
        {
            bool currentHasAuth = Object.HasStateAuthority;
            if(currentHasAuth != hasAuthority)
            {
                hasAuthority = currentHasAuth;
                OnAuthorityChanged?.Invoke(Object.HasStateAuthority);
            }            
        }
    }
}

