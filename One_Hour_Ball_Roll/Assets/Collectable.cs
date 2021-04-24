using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static List<Collectable> collectables;
    public static List<Vector3> originalBobs;
    private int index;
    Vector3 bobStart;
    // Start is called before the first frame update
    public static void ResetCollectables()
    {
        foreach(Collectable collectable in collectables)
        {
            if(!collectable.gameObject.active)
                collectable.gameObject.SetActive(true);
        }
    }
    void Start()
    {
        if(collectables == null)
        {
            collectables = new List<Collectable>();

        }
    

        collectables.Add(this);
        
    }
    private void OnEnable() {
        if(originalBobs == null)
            originalBobs = new List<Vector3>();
                if(originalBobs.Count < 9)
        {
            originalBobs.Add(this.transform.position);
            index = originalBobs.Count-1;

        }
        bobStart = originalBobs[index] + Vector3.up;

        StartCoroutine(bob());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator bob()
    {
        Vector3 bobEnd = transform.position;
        float t = 0;
        float tick = .004f;
        while(true)
        {
            transform.position = Vector3.Lerp(bobStart,bobEnd, t);
            t += tick;
            if(t >= 1)
                tick = -.004f;
            if(t <= 0)
                tick = .004f;
            yield return null;
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.name == "Player")
        {
            BeatGame.Collectables++;
            gameObject.SetActive(false);
        }
    }
}
