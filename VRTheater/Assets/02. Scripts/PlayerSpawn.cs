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
        player = PhotonNetwork.Instantiate("Player", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(player);
    }
}