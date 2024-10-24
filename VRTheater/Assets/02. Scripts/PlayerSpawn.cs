using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviourPunCallbacks
{
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        string selectAvatar = (string)PhotonNetwork.LocalPlayer.CustomProperties["Avatar"];

        PhotonNetwork.Instantiate(selectAvatar, transform.position, transform.rotation);
        Debug.Log(PhotonNetwork.CurrentRoom.Name); 
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
    }
}