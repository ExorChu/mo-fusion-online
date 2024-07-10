using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace MOFusion
{
    [RequireComponent(typeof(GameNetworkEvents))]
    public class GameManager : Fusion.Behaviour
    {
        public delegate void DelPlayerConnectedEvent(PlayerRef playerRef);
        public delegate void DelPlayerDisconnectedEvent(PlayerRef playerRef, string playerId);


        public event DelPlayerConnectedEvent OnPlayerConnected;
        public event DelPlayerDisconnectedEvent OnPlayerDisconnected;

        public bool IsServer
        {
            get
            {
#if SERVER_MODE
                return true;
#endif
                return runner == null ? false : runner.IsSharedModeMasterClient;
            }
        }

        [SerializeField, HideInInspector] private NetworkRunner runner;
        [SerializeField, HideInInspector] private GameNetworkEvents gameNetworkEvents;

        private Dictionary<PlayerRef, string> players;

        private void Reset()
        {
            runner = GetComponent<NetworkRunner>();
            gameNetworkEvents = GetComponent<GameNetworkEvents>();
        }

        private void Awake()
        {
            players = new Dictionary<PlayerRef, string>();
            gameNetworkEvents.OnConnectedToServer += GameNetworkEvents_OnConnectedToServer;
        }

        private void GameNetworkEvents_OnConnectedToServer(NetworkRunner runner)
        {
            if(IsServer)
            {
                gameNetworkEvents.OnPlayerJoined += GameNetworkEvents_OnPlayerJoined;
                gameNetworkEvents.OnPlayerLeft += GameNetworkEvents_OnPlayerLeft;
            }
        }               

        private void GameNetworkEvents_OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            if (runner.LocalPlayer == player)
                return;

            //check if player is acceptable
            players[player] = runner.GetPlayerUserId(player);
            OnPlayerConnected?.Invoke(player);
        }

        private void GameNetworkEvents_OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {

            if(players.Remove(player, out string playerId))
            {
                OnPlayerDisconnected?.Invoke(player, playerId);
            }
        }

        public string GetPlayerId(PlayerRef player)
            => players.TryGetValue(player, out string playerId) ? playerId : null;

        public bool TryGetPlayerId(PlayerRef player, out string playerId)
            => players.TryGetValue(player, out playerId);
    }
}