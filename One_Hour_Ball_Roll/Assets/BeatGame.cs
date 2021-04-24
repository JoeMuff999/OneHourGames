using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BeatGame : MonoBehaviour
{
    public static int Collectables = 0;
    public GameObject WinCanvas;
    public Text winText;
    private void OnTriggerEnter(Collider other) {
        if(other.name == "Player")
        {
            winText.text = "Congrats, you win! You collected " + Collectables + " out of 7 collectables - nice work! Press R to restart";
            WinCanvas.SetActive(true);
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
        WinCanvas.SetActive(false);

    }
}
