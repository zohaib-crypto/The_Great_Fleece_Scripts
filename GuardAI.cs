using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    private int _currentTarget;
    private NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        if (wayPoints.Count != 0 && wayPoints[_currentTarget] != null)
        {
            _agent.SetDestination(wavePoints[_currentTarget]);
        }
    }
}
