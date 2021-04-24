using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Camera playerCamera;
    Rigidbody rb;
    public Vector3 cameraOffset;
    public Vector3 cameraRotation;

    public float gravityScale;
    public float globalGravity = -9.81f;

    public float constantZ = 10f;


    public Transform spawnPoint; 
    private float globalTimeDiff;
    // Start is called before the first frame update

    private void Awake() {
        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        globalTimeDiff = 0;
    }

    private void FixedUpdate() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float forwardInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, constantZ + globalTimeDiff);
        rb.AddForce(gravityScale * globalGravity * Vector3.up, ForceMode.Acceleration);
        // rb.AddForce(boopForce * Vector3.forward, ForceMode.Acceleration);
    
    }

    // Update is called once per frame
    void Update()
    {
globalTimeDiff += Time.deltaTime;
        playerCamera.transform.position = new Vector3(transform.position.x + cameraOffset.x, transform.position.y + cameraOffset.y, transform.position.z + cameraOffset.z);
        playerCamera.transform.eulerAngles = cameraRotation;
    }

    public void ResetPlayer()
    {
        transform.position = spawnPoint.position;
        rb.velocity = Vector3.zero;
        Collectable.ResetCollectables();
        globalTimeDiff = 0;
        BeatGame.Collectables = 0;
    }
}
