// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class PlayerController : MonoBehaviour
// {
//     private Animator _anim;
//     private Vector3 _target;
//     private NavMeshAgent _agent;
//     float _distance;
//     void Start()
//     {
//         _agent = GetComponent<NavMeshAgent>();
//         _anim = GetComponentInChildren<Animator>();
//     }


//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//             Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
//             RaycastHit hitInfo;

//             if (Physics.Raycast(rayOrigin, out hitInfo))
//             {
//                 //moving our player to the point where we are clicking
//                 _agent.SetDestination(hitInfo.point);
//                 _anim.SetBool("isWalking", true);

//             }

//         }
//         if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
//         {
//             _anim.SetBool("isWalking", false);

//         }
//     }
// }

