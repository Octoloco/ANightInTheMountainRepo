using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleIce : MonoBehaviour
{
 
    [SerializeField] Vector3 scale;
    [Range(0.5f,3)][SerializeField] float time=1;
    float factorScale = 0;
    
  
    // Update is called once per frame

    private void Start()
    {
        factorScale= ((scale - transform.localScale).magnitude / time);
        Debug.Log(factorScale);
    }

    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, scale, factorScale * Time.deltaTime);
    }
}
