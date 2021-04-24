using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, Controls.IPlayerActions
{

    public static Player player;

    public GameObject Ball;

    public GameObject Hands;
    private Controls controls = null;

    private Rigidbody rb;
    [SerializeField] private float movementSpeed;

    [SerializeField] private float jumpPower;

    [SerializeField] private float hitThreshold;

    [SerializeField] private float hitPower;

    private bool isGrounded;

    private bool holdingBall;
    [SerializeField] private float tossPower;



    private void Awake() {
        controls = new Controls();
        rb = GetComponent<Rigidbody>();
        player = this;
    }
    private void Update() {
        Move();
    }

    private void OnEnable() {
        if(controls == null)
            return;
        controls.Player.Enable();
    }

    private void OnDisable() {
        controls.Player.Disable();
    }
    private void Move() {
        var movementInput = controls.Player.Move.ReadValue<Vector2>();
        var movement = new Vector3
        {
            z = -movementInput.x,
            x = movementInput.y
        };

        movement.Normalize();
        
        transform.Translate(movement * movementSpeed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision other) {
        isGrounded = true;
    }
    public void Jump() {
        if(!isGrounded)
            return;

        rb.AddForce(Vector3.up * jumpPower);
        isGrounded = false;
    }

    public void HitBall(){
        float distance = Vector3.Distance(transform.position, Ball.transform.position);
        if(distance > hitThreshold || holdingBall)
            return;

        Vector2 lateralForce = new Vector2{
            x = 0,
            y = 0
        };

        Ball.GetComponent<Rigidbody>().AddForce(Vector3.right * hitPower);
    }

    public void TossBall(){
        if(!holdingBall)
            return;
        DropBall();
        Ball.GetComponent<Rigidbody>().AddForce(Vector3.up * tossPower);
    }

    public void PickupBall()
    {
        
        //Debug.Log("test");
        if(holdingBall)
        {            
            DropBall();
            return;
        }

        float distance = Vector3.Distance(transform.position, Ball.transform.position);
        if(distance > hitThreshold)
            return;

        Ball.transform.parent = Hands.transform;
        Ball.transform.localPosition = Vector3.zero;
        Ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        holdingBall = true;
    }

    private void DropBall()
    {
        Ball.transform.parent = null;
        Ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        
        holdingBall = false;
    }

    public void OnHit(InputAction.CallbackContext context)
    {
        if(context.started)
            HitBall();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started)
            Jump();
    }

    public void OnPickup(InputAction.CallbackContext context)
    {
        if(context.started)
            PickupBall();
    }

    public void OnToss(InputAction.CallbackContext context)
    {
        if(context.started)
            TossBall();
    }

    public void OnMove(InputAction.CallbackContext context) => throw new System.NotImplementedException();

    //implemented in Game.cs   
    public void OnSpawnBall(InputAction.CallbackContext context) => throw new System.NotImplementedException();

    public void OnLook(InputAction.CallbackContext context) => throw new System.NotImplementedException();

}
