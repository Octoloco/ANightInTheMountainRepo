using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPanelBehaviour : MonoBehaviour
{
    [SerializeField]
    private float openTimer;
    [SerializeField]
    private float closeTimer;

    private bool opened;
    private bool closed;

    void Update()
    {
        if (!closed)
        {
            if (openTimer > 0)
            {
                openTimer -= Time.deltaTime;
            }
            else
            {
                if (!opened)
                {
                    opened = true;
                    GetComponent<TextPanel>().Show();
                }
                else if (closeTimer > 0)
                {
                    closeTimer -= Time.deltaTime;
                }
                else
                {
                    if (!closed)
                    {
                        closed = true;
                        GetComponent<TextPanel>().Hide();
                    }
                }
            }
        }
    }
}
