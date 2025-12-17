using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    [SerializeField] private int _currentTarget;
    private NavMeshAgent _agent;
    private bool _reverse;
    private bool _targetReached;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        if (wayPoints.Count != 0 && wayPoints[_currentTarget] != null)
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);

            if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance && _targetReached == false)
            {
                _targetReached = true;

                StartCoroutine(WaitBeforeMoving());
            }
        }
    }
    IEnumerator WaitBeforeMoving()
    {
        yield return new WaitForSeconds(2.0f);

        if (_reverse == true)
        {
            _currentTarget--;

            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }

        //     else if (_reverse == false)
        //     {
        //         _currentTarget++;

        //         if (_currentTarget == wayPoints.Count)
        //         {
        //             _reverse = true;
        //             _currentTarget--;
        //         }
        //     }
        //     _targetReached = false;
        // }
    }


