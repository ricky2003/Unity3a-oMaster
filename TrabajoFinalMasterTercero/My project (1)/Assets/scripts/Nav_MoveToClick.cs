using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Nav_MoveToGrip : MonoBehaviour
{
    public Camera cam;
    private NavMeshAgent agent;
    public Scene EndGame;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        
        
    }
    

}
