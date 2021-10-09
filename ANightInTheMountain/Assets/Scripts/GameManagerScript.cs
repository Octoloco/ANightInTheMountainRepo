using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    GameObject playerPrefab;

    PlayerMovement player;

    void Update()
    {
        if (player == null)
        {
            GameObject temp = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
            player = temp.GetComponent<PlayerMovement>();
        }
    }
}
