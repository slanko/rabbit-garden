using Photon.Pun;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSetupController : MonoBehaviour
{
    public static gameSetupController GS;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (gameSetupController.GS == null)
        {
            gameSetupController.GS = this;
        }
    }

}
