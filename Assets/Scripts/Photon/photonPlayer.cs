using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photonPlayer : MonoBehaviour
{
    private PhotonView PV;
    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            Debug.Log("spawning a player");
            playerObject = PhotonNetwork.Instantiate("Prefabs/player", Vector3.zero, Quaternion.identity);
        }
    }
}
