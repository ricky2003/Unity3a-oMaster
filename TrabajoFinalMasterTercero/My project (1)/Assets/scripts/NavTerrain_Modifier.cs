using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.AI;

public class NavTerrain_Modifier : MonoBehaviour
{
    private NavMeshModifier _meshSurface;
    // Start is called before the first frame update
    void Start()
    {
        _meshSurface = GetComponent<NavMeshModifier>();



    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if(other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            if (_meshSurface.AffectsAgentType(agent.agentTypeID)){ 
                agent.speed /= NavMesh.GetAreaCost(_meshSurface.area);// es lo mismo que hacer esto: agent.speed / NavMesh.GetAreaCost(_meshSurface.area)
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            if (_meshSurface.AffectsAgentType(agent.agentTypeID)){
                agent.speed *= NavMesh.GetAreaCost(_meshSurface.area);
            }
        }
    }
}
