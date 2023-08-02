using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlViaAxis : MonoBehaviour
{
    public float brzinaKretanja;
    public float jumpForce;
    public float dashForce;

    [Header("Samo prikaz")]
    public float horMove;
    public float vertMove;
    [SerializeField] bool isGrounded;
    public Transform groundCheck;
    float groundDist = 0.5f;
    public LayerMask groundLayerMask;


    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundLayerMask);
        horMove = Input.GetAxis("Horizontal");
        vertMove = Input.GetAxis("Vertical");

        Vector3 forwardDirection = transform.forward * vertMove;
        Vector3 rightDirection = transform.right * horMove;
        Vector3 movement = (forwardDirection + rightDirection).normalized * brzinaKretanja;

        rigid.velocity = new Vector3(movement.x, rigid.velocity.y, movement.z);

        ////Handle player rotation
        //float rotInput = Input.GetAxis("Horizontal");
        //Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotInput * brzinaRotacije * Time.deltaTime);
        //rigid.MoveRotation(rigid.rotation * deltaRotation);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    Dash();
        //}


    }


    private void Jump()
    {
        rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        print("jump");
    }
    //private void Dash()
    //{
    //    rigid.AddForce(Vector3.forward * dashForce, ForceMode.Impulse);
    //    print("dash");
    //}
}
