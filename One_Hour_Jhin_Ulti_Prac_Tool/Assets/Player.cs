using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour
{
    NavMeshAgent nav;

    private bool isUlting = false;
    public int shotAmount = 4;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && !isUlting)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100f))
            {
                if(hit.collider.tag == "Navigable")
                {
                    nav.velocity = Vector3.zero;
                    nav.destination = hit.point;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            isUlting = true;
            nav.velocity = Vector3.zero;
            nav.destination = transform.position;
            StartCoroutine(UltimateCoroutine());
            
        }

    }

    IEnumerator UltimateCoroutine()
    {
        while(shotAmount > 0)
        {
            if(Input.GetMouseButtonDown(1))
            {
                shotAmount--;
            }
            yield return null;
        }
        isUlting = false;
        
    }

    
}
