using UnityEngine;
using System.Collections;

public class PhotonManager : Photon.MonoBehaviour
{
    public string objectName;

    void Start()
    {
        // Photonへの接続を行う
        PhotonNetwork.ConnectUsingSettings("0.1");

        // PhotonNetworkの更新回数のセット
        PhotonNetwork.sendRate = 30;
    }

    /// <summary>
    /// ロビーに接続すると呼ばれるメソッド
    /// </summary>
    void OnJoinedLobby()
    {
        // ランダムでルームに入室する
        PhotonNetwork.JoinRandomRoom();
    }

    /// <summary>
    /// ランダムで部屋に入室できなかった場合呼ばれるメソッド
    /// </summary>
    void OnPhotonRandomJoinFailed()
    {
        // ルームを作成、部屋名は今回はnullに設定
        PhotonNetwork.CreateRoom(null);
    }

    /// <summary>
    /// ルームに入室成功した場合呼ばれるメソッド
    /// </summary>
    void OnJoinedRoom()
    {
        GameObject cube = PhotonNetwork.Instantiate(objectName, Vector3.zero, Quaternion.identity, 0);
    }

    /// <summary>
    /// UnityのGameウィンドウに表示させる
    /// </summary>
    void OnGUI()
    {
        // Photonのステータスをラベルで表示させています
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
}