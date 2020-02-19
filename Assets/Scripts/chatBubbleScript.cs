using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chatBubbleScript : MonoBehaviour
{
    public Camera cambera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(cambera == null)
        {
            cambera = (Camera)FindObjectOfType(typeof(Camera));
        }
        else
        {
            transform.LookAt(cambera.transform.position);
        }
    }
}
