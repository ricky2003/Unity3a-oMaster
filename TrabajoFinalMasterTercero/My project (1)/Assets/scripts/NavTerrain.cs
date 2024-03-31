using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.AI;

public class NavTerrain : MonoBehaviour
{
    private NavMeshModifier _meshSurface;
    // Start is called before the first frame update
    void Start()
    {
        _meshSurface = GetComponent<NavMeshModifier>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrada");
        if(other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            agent.speed /= NavMesh.GetAreaCost(_meshSurface.area);
            if (_meshSurface.AffectsAgentType(agent.agentTypeID))
            {
                agent.speed /= NavMesh.GetAreaCost(_meshSurface.area);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("salida");
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            if (_meshSurface.AffectsAgentType(agent.agentTypeID))
            {
                agent.speed *= NavMesh.GetAreaCost(_meshSurface.area);
            }
        }
    }

}
