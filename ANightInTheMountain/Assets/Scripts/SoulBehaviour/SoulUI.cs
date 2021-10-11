using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoulUI : MonoBehaviour
{
    [SerializeField] SoulsController souls;
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = souls.CurrentSouls.ToString();
    }
}
