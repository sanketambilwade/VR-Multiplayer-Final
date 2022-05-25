using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateLobby : MonoBehaviourPunCallbacks
{
    public static CreateLobby instance;

    public InputField create;
    public InputField join;

    public GameObject errorScreen;
    public Text errorText;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        errorScreen.SetActive(false);
    }
    public void Createroom()
    {
        if (create.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(create.text);
        }
    }

    public void Joinroom()
    { 
       PhotonNetwork.JoinRoom(join.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Scene 1");
        Debug.Log("Player Joined Room"); 

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Failed to Create Room: " + message;
        errorScreen.SetActive(true);
    }

    public void CloseErrorScreen()
    {
        errorScreen.SetActive(false);
        PhotonNetwork.LoadLevel("Lobby");
    }
}
