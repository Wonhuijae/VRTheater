using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Room
{
    public string roomName;
    public int sceneIdx;
}

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public GameObject selectRoomUI;
    public GameObject textWarning;

    public TextMeshProUGUI noticeInputName;
    public TextMeshProUGUI noticeSelectRoom;

    public TMP_InputField inputPlayerName;
    public TMP_Dropdown selectRoomDropDown;

    private void Start()
    {
        ServerConnect();
    }

    public void ServerConnect()
    {
        // 접속 시도
        PhotonNetwork.ConnectUsingSettings();
    }

    // 콜백 함수. 클라이언트가 마스터 서버에 연결되었을 때 호출됨
    // 서버 연결을 확인하고 연결되었다면 다음 작업 호출
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log(PhotonNetwork.CurrentLobby.Name);
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;

        int dropIdx = selectRoomDropDown.value;

        PhotonNetwork.JoinOrCreateRoom(selectRoomDropDown.options[dropIdx].text,
                                        roomOptions,
                                        TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("MainScene");
    }

    public void SaveName()
    {
        if(inputPlayerName.text == "")
        {
            textWarning.SetActive(true);
            return;
        }

        PhotonNetwork.LocalPlayer.NickName = inputPlayerName.text;
        
        noticeInputName.gameObject.SetActive(false);
        inputPlayerName.gameObject.SetActive(false);

        selectRoomDropDown.gameObject.SetActive(true);
        noticeSelectRoom.gameObject.SetActive(true);
    }
}
