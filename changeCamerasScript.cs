using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCamerasScript : MonoBehaviour {
    public Camera camera1;
    public Camera camera2;
    private AudioListener aud1;
    private AudioListener aud2;

    // Use this for initialization
    void Start () {
        aud1 = camera1.GetComponent<AudioListener>();
        aud2 = camera1.GetComponent<AudioListener>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        print("trigger 1 entered");
        
        camera1.enabled = true;
        aud1.enabled = true;
        camera2.enabled = false;
        aud2.enabled = false;
    }
}
