using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class networkController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected 2 the " + PhotonNetwork.CloudRegion + " server yo");
    }
}
