using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    public Transform currentTarget;
    private NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (wayPoints.Count > 0)
        {
            if (wayPoints[0] != null)
            {
                currentTarget = wayPoints[0];
                _agent.SetDestination(currentTarget.position);
            }
        }
    }
    void Update()
    {

    }
}
