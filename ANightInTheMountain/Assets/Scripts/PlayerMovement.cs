using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool moving;

    private PlayerInputActions playerInputActions;
    private InputAction movement;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Movement;
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    private void Start()
    {
        moving = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!moving)
        {
            Debug.Log($"Can move with value {movement.ReadValue<Vector2>().magnitude}");
            if (movement.ReadValue<Vector2>().magnitude > .3f)
            {
                if (!(movement.ReadValue<Vector2>().x > .2f && movement.ReadValue<Vector2>().y > .2f) &&
                    !(movement.ReadValue<Vector2>().x < -.2f && movement.ReadValue<Vector2>().y < -.2f) && 
                    !(movement.ReadValue<Vector2>().x > .2f && movement.ReadValue<Vector2>().y < -.2f) && 
                    !(movement.ReadValue<Vector2>().x < -.2f && movement.ReadValue<Vector2>().y > .2f))
                {
                    moving = true;
                    GetComponent<Rigidbody>().velocity = new Vector3(movement.ReadValue<Vector2>().x, 0, movement.ReadValue<Vector2>().y) * speed;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        moving = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}

