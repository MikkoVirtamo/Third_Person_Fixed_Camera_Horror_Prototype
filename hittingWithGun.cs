using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hittingWithGun : MonoBehaviour
{
    [SerializeField]
    private GameObject hitMarkerPrefab;
    [SerializeField]
    private GameObject enemyHitMarkerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, new Vector3(-5,0,0), Color.green);
        // creates a spark where bullet hits
        if (Input.GetKeyDown(KeyCode.Space) && PlayerHandler.isFiring && PlayerHandler.canFire)
        {
            StartCoroutine(CreateSpark());
        }
    }

    IEnumerator CreateSpark()
    {
        yield return new WaitForSeconds(.1f);
        
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(myRay, out hit))
        {
            // bloody hit for things tagged as "enemy"
            // and a spark for other things
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "enemy")
            {
                Instantiate(enemyHitMarkerPrefab, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else { Instantiate(hitMarkerPrefab, hit.point, Quaternion.LookRotation(hit.normal)); }
        }
    }
}
