using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    private PhotonView photonView;

    void Start()
    {
        photonView = PhotonView.Get(this);
    }

    void Update()
    {
        if (photonView.isMine)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            transform.Translate(x * 0.2f, 0, z * 0.2f);
        }
    }
}