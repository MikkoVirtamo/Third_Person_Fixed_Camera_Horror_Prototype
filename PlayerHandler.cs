using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tank Controls

public class PlayerHandler : MonoBehaviour {
    public static bool haveGun;
    public float moveSpeed;
    public float turnSpeed;
    public static bool canFire;
    public static bool canFire2;
    public static bool isFiring;
    [SerializeField]
    private GameObject holdingGun;
    [SerializeField]
    private GameObject firingGun;
    Animator anim;
	// Use this for initialization
	void Start () {
        //haveGun set to true for testing purposes
        haveGun = true;
        //haveGun = false;
        canFire = true;
        isFiring = false;
        canFire2 = true;
		anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        movement();
        //can aim and shoot if holding gun
        if (haveGun)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl)&&haveGun)
            {
                holdingGun.SetActive(false);
                firingGun.SetActive(true);
                isFiring = true;
                anim.SetBool("holdingAttack", true);

            }
            if (Input.GetKeyUp(KeyCode.LeftControl)&&haveGun)
            {
                holdingGun.SetActive(true);
                firingGun.SetActive(false);
                anim.SetBool("holdingAttack", false);
                isFiring = false;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canFire&&canFire2)
            {
                canFire2 = false;
                canFire = false;
                shoot();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            canFire2 = true;
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            anim.SetBool("firingGun", false);
        }
        
		
		
	}

    //fires gun and starts coroutine to wait until next shot can be fired
    private void shoot()
    {
        anim.SetBool("firingGun", true);
        
        StartCoroutine(waitForGun());
    }
    IEnumerator waitForGun()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("firingGun", false);
        canFire = true;
    }
    private void movement()
    {
        //can't move while aiming
        if (Input.GetKeyDown(KeyCode.LeftControl)&&haveGun)
        {
            anim.SetBool("WalkingForward", false);
        }
        if (Input.GetKey("w"))
        {
            if (Input.GetKey(KeyCode.LeftControl) && haveGun) { }
            else
            {
                anim.SetBool("WalkingForward", true);
                transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKeyUp("w"))
        {
            anim.SetBool("WalkingForward", false);
        }
        if (Input.GetKey("w") && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("running", true);
            transform.Translate(new Vector3(0, 0, 1) * moveSpeed * 1.01f * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("running", false);
        }
        if (Input.GetKey("s") /*&& !Input.GetKey(KeyCode.LeftControl)*/)
        {
            if (Input.GetKey(KeyCode.LeftControl) && haveGun) { }
            else
            {
                anim.SetBool("walkingBackwards", true);
                transform.Translate(new Vector3(0, 0, -.6f) * moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKeyUp("s"))
        {
            anim.SetBool("walkingBackwards", false);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(new Vector3(0, -9, 0) * turnSpeed * Time.deltaTime);
            //transform.Rotate += new Vector3(0,1,0);
        }
        else if (Input.GetKey("d"))
        {
            transform.Rotate(new Vector3(0, 9, 0) * turnSpeed * Time.deltaTime);
        }
        //transform.Rotate += new Vector3(0,-1,0);

    }
}
