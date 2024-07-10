using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MOFusion
{
    public class GameNetworkEvents : Fusion.Behaviour, INetworkRunnerCallbacks
    {
        public delegate void DelConnectedToServer(NetworkRunner runner);
        public delegate void DelConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason);
        public delegate void DelConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token);
        public delegate void DelCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data);
        public delegate void DelDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason);
        public delegate void DelHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken);
        public delegate void DelInput(NetworkRunner runner, NetworkInput input);
        public delegate void DelInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input);
        public delegate void DelObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player);
        public delegate void DelObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player);
        public delegate void DelPlayerJoined(NetworkRunner runner, PlayerRef player);
        public delegate void DelPlayerLeft(NetworkRunner runner, PlayerRef player);
        public delegate void DelReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress);
        public delegate void DelReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data);
        public delegate void DelSceneLoadDone(NetworkRunner runner);
        public delegate void DelSceneLoadStart(NetworkRunner runner);
        public delegate void DelSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList);
        public delegate void DelShutdown(NetworkRunner runner, ShutdownReason shutdownReason);
        public delegate void DelUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message);

        public event DelConnectedToServer OnConnectedToServer;
        public event DelDisconnectedFromServer OnDisconnectedFromServer;
        public event DelConnectFailed OnConnectFailed;
        public event DelConnectRequest OnConnectRequest;
        public event DelCustomAuthenticationResponse OnCustomAuthenticationResponse;
        public event DelHostMigration OnHostMigration;
        public event DelInput OnInput;
        public event DelInputMissing OnInputMissing;
        public event DelObjectEnterAOI OnObjectEnterAOI;
        public event DelObjectExitAOI OnObjectExitAOI;
        public event DelPlayerJoined OnPlayerJoined;
        public event DelPlayerLeft OnPlayerLeft;
        public event DelReliableDataProgress OnReliableDataProgress;
        public event DelReliableDataReceived OnReliableDataReceived;
        public event DelSceneLoadDone OnSceneLoadDone;
        public event DelSceneLoadStart OnSceneLoadStart;
        public event DelSessionListUpdated OnSessionListUpdated;
        public event DelShutdown OnShutdown;
        public event DelUserSimulationMessage OnUserSimulationMessage;

        void INetworkRunnerCallbacks.OnConnectedToServer(NetworkRunner runner)
        {
            OnConnectedToServer?.Invoke(runner);
        }

        void INetworkRunnerCallbacks.OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
            OnConnectFailed?.Invoke(runner, remoteAddress, reason);
        }

        void INetworkRunnerCallbacks.OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
            OnConnectRequest?.Invoke(runner, request, token);
        }

        void INetworkRunnerCallbacks.OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
            OnCustomAuthenticationResponse?.Invoke(runner, data);
        }

        void INetworkRunnerCallbacks.OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
        {
            OnDisconnectedFromServer?.Invoke(runner, reason);
        }

        void INetworkRunnerCallbacks.OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
            OnHostMigration?.Invoke(runner, hostMigrationToken);
        }

        void INetworkRunnerCallbacks.OnInput(NetworkRunner runner, NetworkInput input)
        {
            OnInput?.Invoke(runner, input);
        }

        void INetworkRunnerCallbacks.OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
            OnInputMissing?.Invoke(runner, player, input);
        }

        void INetworkRunnerCallbacks.OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
            OnObjectEnterAOI?.Invoke(runner, obj, player);
        }

        void INetworkRunnerCallbacks.OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
        {
            OnObjectExitAOI?.Invoke (runner, obj, player);
        }

        void INetworkRunnerCallbacks.OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            OnPlayerJoined?.Invoke(runner, player);
        }

        void INetworkRunnerCallbacks.OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
            OnPlayerLeft?.Invoke(runner, player);
        }

        void INetworkRunnerCallbacks.OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
        {
            OnReliableDataProgress?.Invoke(runner, player, key, progress);
        }

        void INetworkRunnerCallbacks.OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
        {
            OnReliableDataReceived?.Invoke(runner, player, key, data);
        }

        void INetworkRunnerCallbacks.OnSceneLoadDone(NetworkRunner runner)
        {
            OnSceneLoadDone?.Invoke(runner);
        }

        void INetworkRunnerCallbacks.OnSceneLoadStart(NetworkRunner runner)
        {
            OnSceneLoadStart?.Invoke(runner);
        }

        void INetworkRunnerCallbacks.OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
            OnSessionListUpdated?.Invoke(runner, sessionList);
        }

        void INetworkRunnerCallbacks.OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
            OnShutdown?.Invoke(runner, shutdownReason); 
        }

        void INetworkRunnerCallbacks.OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
            OnUserSimulationMessage?.Invoke(runner, message);
        }
    }
}