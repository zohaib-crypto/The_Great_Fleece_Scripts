using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _cameraPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger Activate");
            Camera.main.transform.position = _cameraPos.transform.position;
            Camera.main.transform.rotation = _cameraPos.transform.rotation;
        }
    }

}
