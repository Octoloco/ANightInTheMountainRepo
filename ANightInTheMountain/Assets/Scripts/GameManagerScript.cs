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
    [Header("Souls events")]
    [SerializeField] SoulsController soulsController;
    [SerializeField] UnityEvent onAddedSoul;
    [SerializeField] UnityEvent onRemoveSouls;

    private void Start()
    {
        soulsController.soulsAdded = false;
        soulsController.soulsRemove = false;
        soulsController.AddSouls(100);
        onFalling.AddListener(IceAnimation);
    }
    void Update()
    {
        if (soulsController.soulsAdded)
        {
            Debug.Log("OnUpdate added");
            soulsController.soulsAdded = false;
            onAddedSoul.Invoke();

        }
        if (soulsController.soulsRemove)
        {
            Debug.Log("OnUpdate remove");
            soulsController.soulsRemove = false;

            onRemoveSouls.Invoke();
        }
        if (player == null)
        {

            playerInstantiation = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
            player = playerInstantiation.GetComponent<PlayerMovement>();
            iceAnimationActivate = false;


        }
        else if (player.falled && !iceAnimationActivate)
        {
            iceAnimationActivate = true;
        
            onFalling?.Invoke();

        }
        if(player.Fallin)
        {
            player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Fall");
        }
    }

    public void IceAnimation()
    {
        Debug.Log(player.transform.position);
        Vector3 spwanPosition = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
        spwanPosition = new Vector3(Mathf.RoundToInt(spwanPosition.x), spwanPosition.y, Mathf.RoundToInt(spwanPosition.z));
        GameObject tempIce = Instantiate(icePrefab, spwanPosition, Quaternion.identity) as GameObject;

        currentIce.Add(icePrefab);


    }

    public void TestMessageForSouls(string message)
    {
        Debug.Log(message);
    }
}
