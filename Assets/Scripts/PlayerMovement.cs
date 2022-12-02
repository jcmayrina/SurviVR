using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody myRb;
    Vector2 moveInput;

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }
    void Update(){
        Playermove();
    }
    void Playermove(){
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //Vector3 direction = new Vector3(horizontal,0,vertical);
        //velocity = Camera.main.transform.TransformDirection(velocity);
        //velocity.y -= gravity;
        //controller.Move(velocity * Time.deltaTime);
        Vector3 playerVelocity = new Vector3(moveInput.x * speed, myRb.velocity.y, moveInput.y * speed);
        myRb.velocity = transform.TransformDirection(playerVelocity);
    }
    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }
}