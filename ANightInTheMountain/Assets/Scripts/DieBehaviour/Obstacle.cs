using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [HideInInspector] public bool isHit = false;

    public UnityEvent onHitEvent;

    protected abstract void ObstacelEvent();
    public void Hit(Transform player)
    {
        player.parent = transform;
        if (isHit)
        {
            ObstacelEvent();
            onHitEvent?.Invoke();
            isHit = true;
        }

    }

}
