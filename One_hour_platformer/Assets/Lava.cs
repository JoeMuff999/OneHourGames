using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collided with " + other.name);
        if(other.name.Equals("Player"))
        {
            other.GetComponent<PlayerMovement>().ResetPlayer();
        }
    }
}
