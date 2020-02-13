using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class qRoomController : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public static qRoomController room;
    private PhotonView PV;

    public bool isGameLoaded;
    public int multiplayerSceneIndex;
    private int currentScene;
    // Start is called before the first frame update
    public override void OnEnable()
    {
        base.OnEnable();
        if (qRoomController.room == null)
        {
            qRoomController.room = this;
        }
        else
        {
            if(qRoomController.room != this)
            {
                Destroy(qRoomController.room.gameObject);
                qRoomController.room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);

        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("joined tha room baybeeee");
        StartGame();
    }

    private void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("starting a new game 4 u bb");
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);
        }
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.buildIndex;
        if(currentScene == multiplayerSceneIndex)
        {
            CreatePlayer();
        }
    }

    private void CreatePlayer()
    {
        PhotonNetwork.Instantiate("Prefabs/ActualPlayer", Vector3.zero, Quaternion.identity, 0);
    }

}

