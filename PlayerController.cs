using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Animator _anim;
    private Vector3 _target;
    private NavMeshAgent _agent;
    [SerializeField] private GameObject _coin;
    [SerializeField] private AudioClip _coinSoundEffect;
    [SerializeField] private bool _coinThrown;
    float _distance;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                //moving our player to the point where we are clicking
                _agent.SetDestination(hitInfo.point);
                _anim.SetBool("isWalking", true);

            }

        }
        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            _anim.SetBool("isWalking", false);

        }
        if (Input.GetMouseButtonDown(1) && !_coinThrown)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _coinThrown = true;
                Instantiate(_coin, hit.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_coinSoundEffect, hit.point);
                SendAIToCoinSpot(hit.point);
                _anim.SetTrigger("Throw");
            }
        }

    }
    void SendAIToCoinSpot(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach (var guard in guards)
        {
            NavMeshAgent currentGuardAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuardAI = guard.GetComponent<GuardAI>();
            Animator currentGuardAnim = guard.GetComponent<Animator>();
            currentGuardAgent.SetDestination(coinPos);
            currentGuardAI.coinTossed = true;
            currentGuardAnim.SetBool("Walk", true);
            currentGuardAI.coinPos = coinPos;
        }
    }
}

