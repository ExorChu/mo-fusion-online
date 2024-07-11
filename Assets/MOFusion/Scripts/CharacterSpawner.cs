using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOFusion
{
    public class CharacterSpawner : MONetworkBehaviour
    {
        [SerializeField] private NetworkPrefabRef characterPrefab;

        protected override void OnSpawned()
        {
            if(GameManager.IsServer)
            {
                GameManager.OnPlayerConnected += GameManager_OnPlayerConnected;
                GameManager.OnPlayerDisconnected += GameManager_OnPlayerDisconnected;
            }
        }

        protected override void OnDespawned(NetworkRunner runner, bool hasState)
        {
            if (GameManager.IsServer)
            {
                GameManager.OnPlayerConnected -= GameManager_OnPlayerConnected;
                GameManager.OnPlayerDisconnected -= GameManager_OnPlayerDisconnected;
            }
        }

        private void GameManager_OnPlayerConnected(PlayerRef playerRef)
        {
            IPlayerObjectDataProvider dataProvider = GetComponent<IPlayerObjectDataProvider>();
            dataProvider.ProvideData(playerRef, OnObjectDataProvided);
            
        }

        private void OnObjectDataProvided(PlayerRef playerRef, uint[] data)
        {
            RpcSpawnPlayerObject(playerRef, data);
        }

        private void GameManager_OnPlayerDisconnected(PlayerRef playerRef, string playerId)
        {

        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void RpcSpawnPlayerObject([RpcTarget] PlayerRef player, uint[] instantiationData)
        {
            Runner.Spawn(characterPrefab, onBeforeSpawned: (runner, no) =>
            {
                no.GetBehaviour<PlayerObjectInfo>().SetInstantiationData(instantiationData);
            });
        }
    }
}

