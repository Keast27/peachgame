using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableCharacter : MonoBehaviour
{

    

    // Start is called before the first frame update
    float lockPos = 0;
    public float speed; //6
    public bool moveInput = false;
    private Rigidbody rb;
    public float angle; //-140 - Angle for vertical movement
    private Animator anim;
    public float vSpeed; //4 - This helps smooth vertical movement

    public GameObject tile;
    public GameObject colliderCheck;

    public CapsuleCollider left;
    public GameObject right;
    public CapsuleCollider front;
    public CapsuleCollider back;

    public bool collideTestR;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
     //   right = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        collideTestR = right.GetComponent<Ccheck>().isColliding;

       // if (!moveInput) gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        UpdatePos();
        transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, lockPos);
        UpdateAnim();
    }


    void UpdatePos()
    {
        if (Input.GetKey(KeyCode.W) && back.GetComponent<Ccheck>().isColliding)
        {
           
            moveInput = true;
            Debug.Log("W pressed" + moveInput);
            Vector3 Movement = -new Vector3(0, Input.GetAxis("Vertical") * Mathf.Cos(angle) * vSpeed, Input.GetAxis("Vertical") * Mathf.Sin(angle) * vSpeed);
            transform.position += Movement * speed/2 *  Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && front.GetComponent<Ccheck>().isColliding)
        {
            Debug.Log("S pressed");
            moveInput = true;
            Vector3 Movement = -new Vector3(0, Input.GetAxis("Vertical") * Mathf.Cos(angle) * vSpeed, Input.GetAxis("Vertical") * Mathf.Sin(angle) * vSpeed);
            transform.position += Movement * speed/2 * Time.deltaTime;
        }

        // Vertical movement moves at an angle to stay ontop of the grid


        if (Input.GetKey(KeyCode.D) && right.GetComponent<Ccheck>().isColliding )
        {
            Debug.Log("D pressed");
            moveInput = true;
            Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            transform.position += Movement * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A) && left.GetComponent<Ccheck>().isColliding)
        {
            Debug.Log("A pressed");
            moveInput = true;
            Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            transform.position += Movement * speed * Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) &&
            !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            moveInput = false;



            Debug.Log("Nothing pressed, move input: " + moveInput);
            //rb.constraints = RigidbodyConstraints.FreezePosition;
            //Commented out for debugging reasons, will remain commented until colliderCheck is done
            // rb.constraints = RigidbodyConstraints.FreezePositionZ;

        }
    }

    void UpdateAnim()
    {
      anim.SetBool("isWalking", moveInput);
    }
}
