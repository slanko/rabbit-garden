using Photon.Pun;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private PhotonView PV;
    public Animator anim;
    GameObject camBuddy;
    GameObject camBuddyCam;
    public float lerpTime;
    public float camRotateSpeed;
    public float moveSpeed;
    public float turnSpeed;
    RaycastHit shadowLocation;
    public GameObject shadowObject;


    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        camBuddy = GameObject.Find(gameObject.name + "/camOrientThing");
        camBuddyCam = GameObject.Find(gameObject.name + "/camOrientThing/Camera");
        foreach (Camera cameron in Camera.allCameras)
        {
            cameron.enabled = false;
        }
        camBuddyCam.GetComponent<Camera>().enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PV.IsMine)
        {
            camStuff();
            moveStuff();
            animStuff();
        }

        //shadow stuff
        Physics.Raycast(gameObject.transform.position, Vector3.down, out shadowLocation, Mathf.Infinity);
        shadowObject.transform.position = new Vector3(shadowLocation.point.x, shadowLocation.point.y + 0.01f, shadowLocation.point.z);

    }

    void camStuff()
    {
        //camera stuff
        camBuddy.transform.position = new Vector3(Mathf.Lerp(camBuddy.transform.position.x, transform.position.x, lerpTime), Mathf.Lerp(camBuddy.transform.position.y, transform.position.y, lerpTime), Mathf.Lerp(camBuddy.transform.position.z, transform.position.z, lerpTime));
        if (Input.GetKey(KeyCode.E))
        {
            camBuddy.transform.Rotate(0, camRotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            camBuddy.transform.Rotate(0, -camRotateSpeed, 0);
        }
    }

    void moveStuff()
    {
        //movement stuff
        if (anim.GetBool("sittin") == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * ((moveSpeed * Time.deltaTime) * -1));
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, turnSpeed * -1, 0);
                camBuddy.transform.Rotate(0, turnSpeed, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, turnSpeed, 0);
                camBuddy.transform.Rotate(0, turnSpeed * -1, 0);
            }
        }
    }

    void animStuff()
    {
        //animation stuff
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("movementkeyspressed", true);
            anim.SetBool("sittin", false);
        }
        else
        {
            anim.SetBool("movementkeyspressed", false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetBool("sittin", true);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetTrigger("wave");
        }
    }
}
