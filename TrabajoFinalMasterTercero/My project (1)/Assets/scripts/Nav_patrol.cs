using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav_patrol : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject[] wayPoits;
    public GameObject waypoitParent;
    private int waypointIndex = 0;
    private int maxWayPoint;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        maxWayPoint = waypoitParent.transform.childCount;
        wayPoits = new GameObject[maxWayPoint];
        Debug.Log(maxWayPoint);
        for (int i = 0; i < maxWayPoint; i++)
        {
            wayPoits[i] = waypoitParent.transform.GetChild(i).gameObject;
        }
        GoToNextWayPoint();

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.1)
        {
            waypointIndex = (waypointIndex + 1) % maxWayPoint;
            GoToNextWayPoint();
        }

    }
    private void GoToNextWayPoint()
    {
        agent.SetDestination(wayPoits[waypointIndex].transform.position);
    }
}
