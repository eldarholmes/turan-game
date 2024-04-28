using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class ConnectToServer : MonoBehaviour
{
    public NetworkManager manager;
    public Dropdown dropdownIP;
    public Button connectButton;

    void Start()
    {
        connectButton.onClick.AddListener(Connect);
    }

    void Connect()
    {
        if (!NetworkClient.isConnected && !NetworkServer.active)
        {
            if (!NetworkClient.active)
            {
                    manager.networkAddress = "10.1.202.46";
                    manager.StartClient();
            }
        }
    }
}
