using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    GameObject playerPrefab;

    PlayerMovement player;
    GameObject playerInstantiation;
    [Header("Ice Animation")]
    public UnityEvent onFalling = new UnityEvent();
    [SerializeField] GameObject icePrefab;
    List<GameObject> currentIce = new List<GameObject>();
    bool iceAnimationActivate = true;
    private void Start()
    {
        onFalling.AddListener(IceAnimation);
    }
    void Update()
    {
        if (player == null)
        {
           
            playerInstantiation = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
            player = playerInstantiation.GetComponent<PlayerMovement>();
            iceAnimationActivate = false;


        }
        else if (player.Fallin && !iceAnimationActivate)
        {
            iceAnimationActivate = true;
            onFalling?.Invoke();
          
        }
    }

    public void IceAnimation()
    {
        Debug.Log(player.transform.position);
        Vector3 spwanPosition = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        GameObject tempIce = Instantiate(icePrefab, spwanPosition, Quaternion.identity) as GameObject;

        currentIce.Add(icePrefab);
        

    }
}
