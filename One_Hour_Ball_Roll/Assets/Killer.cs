using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public GameObject deathScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.name == "Player")
        {
            deathScreen.SetActive(true);
            StartCoroutine(WaitForRestart(other.GetComponent<Player>()));
        }
    }

    private IEnumerator WaitForRestart(Player player)
    {
        while(!Input.GetKeyDown(KeyCode.R))
        {
            yield return null;
        }
        player.ResetPlayer();
        deathScreen.SetActive(false);

    }
}
