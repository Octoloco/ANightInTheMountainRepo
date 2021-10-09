using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleObstacle : Obstacle
{
    [SerializeField] GameObject icePrefab;


    [SerializeField] Vector3 movement;
    [Range(0.5f, 3)] [SerializeField] float time = 1;
    float factorScale = 0;

    bool startEvent;
    // Update is called once per frame

    private void Start()
    {
        factorScale = ((movement - transform.localScale).magnitude / time);
        Debug.Log(factorScale);
    }



    private void Update()
    {
        if (startEvent)
        {
            GameObject iceTemp = Instantiate(icePrefab);
            iceTemp.transform.parent = transform;

          transform.localPosition= Vector3.MoveTowards(transform.localPosition,movement,factorScale*Time.deltaTime);

        }
    }
    protected override void ObstacelEvent()
    {
        startEvent = true;
    }



}
