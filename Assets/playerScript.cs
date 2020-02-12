using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public Animator anim;
    public GameObject camBuddy;
    public float lerpTime;
    public float camRotateSpeed;
    public float moveSpeed;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camBuddy.transform.position = new Vector3(Mathf.Lerp(camBuddy.transform.position.x, transform.position.x, lerpTime), Mathf.Lerp(camBuddy.transform.position.y, transform.position.y, lerpTime), Mathf.Lerp(camBuddy.transform.position.z, transform.position.z, lerpTime));
        if (Input.GetKey(KeyCode.E))
        {
            camBuddy.transform.Rotate(0, camRotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            camBuddy.transform.Rotate(0, -camRotateSpeed, 0);
        }
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
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnSpeed, 0);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("movementkeyspressed", true);
        }
        else
        {
            anim.SetBool("movementkeyspressed", false);
        }

    }
}
