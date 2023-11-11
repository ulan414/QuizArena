using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public float minX, maxX, minZ, maxZ;

    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ));
         PhotonNetwork.Instantiate(player.name, randomPosition, Quaternion.identity);

        // // Access the transform of the instantiated object and set it as the Cinemachine camera's follow target.
        // Transform objectTransform = InstantiatedObject.transform;
        // vcam.Follow = objectTransform;
    }
}
