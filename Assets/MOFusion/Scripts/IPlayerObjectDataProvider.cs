using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOFusion
{
    public interface IPlayerObjectDataProvider
    {
        public void ProvideData(PlayerRef playerRef, System.Action<PlayerRef, uint[]> callback);
    }

}
