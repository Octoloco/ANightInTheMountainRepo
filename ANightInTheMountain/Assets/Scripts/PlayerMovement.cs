using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float fallSpeed;
    [SerializeField]
    private float fallPositionY;
    private bool canMove;
    private bool dead;
    private bool moving;
    private bool falling;

    private PlayerInputActions playerInputActions;
    private InputAction movement;
    public bool Fallin => falling;

    [SerializeField] float sphereOffsetX;
    [SerializeField] float sphereOffsetZ;
    [SerializeField] float radius;

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
        canMove = true;
    }
    void OnDrawGizmosSelected()
    {
        if (movement.ReadValue<Vector2>().magnitude > .3f)
        {
            Gizmos.color = Color.blue;
            Vector3 result = new Vector3(transform.position.x + movement.ReadValue<Vector2>().x, transform.position.y, transform.position.z + movement.ReadValue<Vector2>().y);
            Gizmos.DrawSphere(result, radius);
        }
        // Draw a yellow sphere at the transform's position

    }
    private void FixedUpdate()
    {

        //Debug.Log(transform.TransformDirection(Vector3.down));
        Debug.DrawLine(new Vector3(transform.position.x - .4f, transform.position.y, transform.position.z), new Vector3(transform.position.x - .4f, transform.position.y - 20, transform.position.z), Color.green);

        if (falling)
        {
            Fall();
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        if (canMove)
        {
            if (movement.ReadValue<Vector2>().magnitude > .3f && !dead)
            {
                if (!(movement.ReadValue<Vector2>().x > .2f && movement.ReadValue<Vector2>().y > .2f) &&
                    !(movement.ReadValue<Vector2>().x < -.2f && movement.ReadValue<Vector2>().y < -.2f) &&
                    !(movement.ReadValue<Vector2>().x > .2f && movement.ReadValue<Vector2>().y < -.2f) &&
                    !(movement.ReadValue<Vector2>().x < -.2f && movement.ReadValue<Vector2>().y > .2f))
                {
                    moving = true;
                    canMove = false;

                    GetComponent<Rigidbody>().velocity = new Vector3(movement.ReadValue<Vector2>().x, 0, movement.ReadValue<Vector2>().y) * speed;
                }
            }
        }
        else
        {
            if (moving)
            {
                int layerMask = 1 << 8;
                layerMask = ~layerMask;
                RaycastHit hit;

                if (GetComponent<Rigidbody>().velocity.x > 0)
                {
                    if (!Physics.Raycast(new Vector3(transform.position.x - .45f, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
                    {
                        dead = true;
                        GetComponent<Rigidbody>().velocity = Vector3.zero;
                        falling = true;
                    }
                }
                else if (GetComponent<Rigidbody>().velocity.x < 0)
                {
                    if (!Physics.Raycast(new Vector3(transform.position.x + .45f, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
                    {
                        dead = true;
                        GetComponent<Rigidbody>().velocity = Vector3.zero;
                        falling = true;
                    }
                }
                else if (GetComponent<Rigidbody>().velocity.z > 0)
                {
                    if (!Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z - .45f), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
                    {
                        dead = true;
                        GetComponent<Rigidbody>().velocity = Vector3.zero;
                        falling = true;
                    }
                }
                else if (GetComponent<Rigidbody>().velocity.z < 0)
                {
                    if (!Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + .45f), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
                    {
                        dead = true;
                        GetComponent<Rigidbody>().velocity = Vector3.zero;
                        falling = true;
                    }
                }
            }
        }
    }

    private IEnumerator ActivateSphereCollider(Vector3 center)
    {
        int framesToWait = 2;
        for (int i = 0; i < framesToWait; i++)
        {
            Collider[] hitColliders = Physics.OverlapSphere(center, radius);
            foreach (var hitCollider in hitColliders)
            {
                Debug.Log(hitCollider.name);
            }
            yield return new WaitForEndOfFrame();
        }

    }

    private void Fall()
    {
        if (transform.position.y > fallPositionY)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(GetComponent<Rigidbody>());
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!dead)
        {
            //Debug.Log($"x factor is: {Mathf.Abs(transform.position.x - collision.transform.position.x)}");
            //Debug.Log($"z factor is: {Mathf.Abs(transform.position.z - collision.transform.position.z)}");
            //if (Mathf.Abs(transform.position.x - collision.transform.position.x) <= 0.5f || Mathf.Abs(transform.position.z - collision.transform.position.z) <= 0.5f)
            //{
            //}
            if (collision.gameObject.CompareTag("spike"))
            {
                transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
                Destroy(GetComponent<Rigidbody>());
                Destroy(this);
            }


        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!dead && !moving)
        {
            canMove = true;
        }

        if (GetComponent<Rigidbody>().velocity.magnitude <= .15f)
        {
            moving = false;
        }
    }
}

