using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storageCameraTriggerScript : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    private AudioListener aud1;
    private AudioListener aud2;

    // Start is called before the first frame update
    void Start()
    {
        aud1 = camera1.GetComponent<AudioListener>();
        aud2 = camera1.GetComponent<AudioListener>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger 1 entered");

        camera1.enabled = true;
        aud1.enabled = true;
        camera2.enabled = false;
        aud2.enabled = false;
        StartCoroutine(turnoffCamera());
    }

    IEnumerator turnoffCamera()
    {
        yield return new WaitForSeconds(2);
        camera1.enabled = false;
        aud1.enabled = false;
        camera2.enabled = true;
        aud2.enabled = true;
        Destroy(this.gameObject);
    }
}
