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
    private Animator _anim;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();

    }
    void Update()
    {
        if (wayPoints.Count != 0 && wayPoints[_currentTarget] != null) //checking if there are wayPoints and also with that index there exits a wayPoint
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);
            float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);
            if (distance < 1 && (_currentTarget == 0 || _currentTarget == wayPoints.Count - 1))
            {

                if (_anim != null)
                {
                    _anim.SetBool("Walk", false);
                }

            }
            else
            {
                if (_anim != null)
                {
                    _anim.SetBool("Walk", true);
                }
            }
            if (wayPoints.Count < 2)
            {
                return;
            }

            if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance && _targetReached == false)
            {

                if (_currentTarget == 0 || _currentTarget == wayPoints.Count - 1) // if we are at start or end
                {
                    _targetReached = true;
                    StartCoroutine(WaitBeforeMoving());
                }
                else //else if we are somewhere in between  
                {
                    if (_reverse == true)
                    {
                        _currentTarget--;
                        _reverse = false;
                    }
                    else
                    {
                        _currentTarget++;
                    }
                }
            }
        }
    }
    IEnumerator WaitBeforeMoving()
    {
        if (_currentTarget == 0)
        {
            yield return new WaitForSeconds(2.0f);

        }
        else if (_currentTarget == wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(2.0f);

        }


        if (_reverse == true)
        {
            _currentTarget--;

            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }

        else if (_reverse == false)
        {
            _currentTarget++;

            if (_currentTarget == wayPoints.Count)
            {
                _reverse = true;
                _currentTarget--;
            }
        }
        _targetReached = false;
    }
}


