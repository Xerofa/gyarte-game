using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    #region Variables

    public static float movementSpeed = 7.5f;
    public static float airMovementSpeed = 5f;
    public float currentMovementSpeed;
    public float jumpSpeed;
    public float fallSpeed;
    private float canJump =0f;
    public float jumpRate;
    public Rigidbody rb;

    public AudioManager aM;
    float timerSound;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentMovementSpeed = movementSpeed;
        aM = GetComponent<AudioManager>();
        aM = FindObjectOfType<AudioManager>();
    }

	void FixedUpdate () 
	{
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * currentMovementSpeed, 0f, 0f, Space.World);
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * currentMovementSpeed, Space.World);

        Vector3 NextDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (NextDir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(NextDir);
    }

    void Update()
    {
        timerSound += Time.deltaTime;

        if (Input.GetKeyDown("space") && Time.time > canJump)
        {
            rb.AddForce (transform.up * jumpSpeed, ForceMode.Impulse);
            rb.AddForce(-transform.up * fallSpeed, ForceMode.Impulse);
            canJump = Time.time + jumpRate;
            currentMovementSpeed = airMovementSpeed;
            aM.Play("Jump");
        }
        if(timerSound > 2f)  //Checks every 2seconds second instead of all the time
        {
             if (rb.velocity.y < 0.05f)
             {
                if(Input.GetButton("Horizontal") || Input.GetButton("Vertical") && timerSound > .7f)
                {
                    aM.Play("PlayerWalk");
                    timerSound = 0f;
                }
             }
             else
             {
                aM.Stop("PlayerWalk");
             }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enviroment")
        {
            if(timerSound > .5f)
            {
                currentMovementSpeed = movementSpeed;
                aM.Play("Land");
            }
        }
    }
}

