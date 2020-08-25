using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemAction : MonoBehaviour
{
    [SerializeField]
    private string nameOfObject;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("You're looking at the box");
        }
    }

}
