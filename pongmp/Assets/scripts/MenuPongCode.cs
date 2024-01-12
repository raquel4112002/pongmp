using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class MenuPongCode : MonoBehaviour
{
    public Button buttonConnect;
    public Button buttonRandomMatch;
    public Button buttonDisconnect;
    public GameObject networkmanager;

    void Awake()
    {
        buttonConnect.interactable = true;
        buttonRandomMatch.interactable = false;
        buttonDisconnect.interactable = false;

        DontDestroyOnLoad(networkmanager);
    }


    public void buttonConnectClicked()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            StartCoroutine(Connecting(3));
        }
    }

    public void buttonRandomMatchClicked()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinLobby();
            buttonConnect.interactable = false;
            buttonRandomMatch.interactable = false;
            buttonDisconnect.interactable = false;
        }
    }

    public void buttonDisconnectClicked()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
            buttonConnect.interactable = true;
            buttonRandomMatch.interactable = false;
            buttonDisconnect.interactable = false;
        }
    }

    IEnumerator Connecting(int time)
    {
        yield return new WaitForSeconds(time);
        buttonConnect.interactable = false;
        buttonRandomMatch.interactable = true;
        buttonDisconnect.interactable = true;
    }
}