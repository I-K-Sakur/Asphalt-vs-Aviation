using Unity.Netcode;
using UnityEngine;

public class PlayerSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject hostPrefab; 
    [SerializeField] private GameObject clientPrefab; 

    [ServerRpc(RequireOwnership = false)]
    public void SpawnPlayerServerRpc(ulong clientId, ServerRpcParams rpcParams = default)
    {
        GameObject newPlayer;
        hostPrefab.SetActive(true);
        clientPrefab.SetActive(true);

        // Log to see if the method is being called
        Debug.Log($"Spawning player for clientId: {clientId}");

        // Check if the client is the host or a regular client
        if (NetworkManager.Singleton.IsHost)
        {
            Debug.Log("Spawning host prefab.");
            newPlayer = Instantiate(hostPrefab);
        }
        else
        {
            Debug.Log("Spawning client prefab.");
            newPlayer = Instantiate(clientPrefab);
        }

        if (newPlayer != null)
        {
            var netObj = newPlayer.GetComponent<NetworkObject>();
            newPlayer.SetActive(true);
            netObj.SpawnAsPlayerObject(clientId, true);
            Debug.Log("Player spawned successfully.");
        }
        else
        {
            Debug.LogError("Failed to instantiate the player prefab.");
        }
    }
}
