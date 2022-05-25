using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Spawn()
    {
        PhotonNetwork.Instantiate("Player", transform.position, transform.rotation);
    }

}
