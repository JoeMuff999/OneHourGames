using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndGame : MonoBehaviour
{

    public GameObject EndGameScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Player")
        {
            EndGameScreen.SetActive(true);
            StartCoroutine(WaitForRestart(other.GetComponent<PlayerMovement>()));            
        }
    }

    private IEnumerator WaitForRestart(PlayerMovement pm)
    {
        while(!Input.GetKeyDown(KeyCode.R))
        {
            yield return null;
        }
        pm.ResetPlayer();
        EndGameScreen.SetActive(false);
    }
}
