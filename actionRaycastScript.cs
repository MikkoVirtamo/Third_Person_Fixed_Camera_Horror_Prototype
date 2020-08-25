using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionRaycastScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    Collider myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = player.GetComponent<Collider>();
    }

    // Update is called once per frame
    // Raycasts for interacting with items
    void Update()
    {
        Debug.DrawRay(transform.position, new Vector3(.7f, 0, 0), Color.red);

        RaycastHit hit;
        Ray myRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(myRay, out hit, .7f))
        {
            //Debug.Log(hit.collider.tag);
            if(hit.collider.tag == "interactable")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    string objname = hit.transform.gameObject.name;
                    //Debug.Log(objname);
                    GameObject g = GameObject.Find(objname);
                    itemAction item = g.GetComponent<itemAction>();
                    //Debug.Log(item.objName);
                    g.SendMessage("OnTriggerStay", myCollider);
                }
            }
           
        }

    }
}
