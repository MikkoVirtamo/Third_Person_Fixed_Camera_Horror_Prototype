using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        //targetPosition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //targetPosition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        // transform.LookAt(target.position);
        transform.LookAt(new Vector3(target.position.x, target.position.y, target.position.z));
    }
}
