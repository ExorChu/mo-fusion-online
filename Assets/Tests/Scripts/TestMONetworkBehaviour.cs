using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOFusion.Tests
{
    public class TestMONetworkBehaviour : MONetworkBehaviour
    {
        protected override void OnSpawned()
        {
            Debug.Log("Is game run on server? " + GameManager.IsServer);

            GameManager.OnPlayerConnected += GameManager_OnPlayerConnected;
            GameManager.OnPlayerDisconnected += GameManager_OnPlayerDisconnected;
        }

        protected override void OnDespawned(NetworkRunner runner, bool hasState)
        {
            GameManager.OnPlayerConnected -= GameManager_OnPlayerConnected;
            GameManager.OnPlayerDisconnected -= GameManager_OnPlayerDisconnected;
        }

        private void GameManager_OnPlayerDisconnected(Fusion.PlayerRef playerRef, string playerId)
        {
            Debug.Log("Player disconnected! " + playerId);
        }

        private void GameManager_OnPlayerConnected(Fusion.PlayerRef playerRef)
        {
            Debug.Log("Player connected!" + GameManager.GetPlayerId(playerRef));
        }


    }
}


