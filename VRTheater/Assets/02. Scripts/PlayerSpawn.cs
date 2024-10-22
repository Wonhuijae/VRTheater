using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviourPunCallbacks
{
    GameObject player;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        string selectAvatar = (string)PhotonNetwork.LocalPlayer.CustomProperties["avatar"];

        player = PhotonNetwork.Instantiate(selectAvatar, transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(player);
    }
}