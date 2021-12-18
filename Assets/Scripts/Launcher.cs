using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject lobby;
    public GameObject room;

    public InputField createInput;
    public InputField joinInput;
    public Text error;

    public Text roomname;
    public Text playercount;

    public GameObject playerlisting;
    public Transform playerlistingcontent;

    public Button start;
    public Transform buttonorganizer;

    public void Start()
    {
        lobby.SetActive(true);
        room.SetActive(false);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(createInput.text))
            return;
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        lobby.SetActive(false);
        room.SetActive(true);

        roomname.text = PhotonNetwork.CurrentRoom.Name;

        Player[] players = PhotonNetwork.PlayerList;

        playercount.text = "" + players.Length;

        for(int i = 0; i < players.Length; i++)
        {
            Instantiate(playerlisting, playerlistingcontent).GetComponent<Playerlisting>().SetPlayerInfo(players[i]);

            if (i == 0)
            {
                start.interactable = true;
            }
            else
            {
                start.interactable = false;
            }
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        error.text = message;
        Debug.Log("Error creating room! " + message);
    }

    public void onclickleaveroom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Loading Scene");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerlisting, playerlistingcontent).GetComponent<Playerlisting>().SetPlayerInfo(newPlayer);
    }

    public void onclickstartgame()
    {
        PhotonNetwork.LoadLevel("Arena");
    }
}