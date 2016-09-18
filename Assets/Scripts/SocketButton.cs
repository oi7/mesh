using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
#if !UNITY_EDITOR
    using Windows.Networking.Sockets;
    using Windows.Networking;
    using Windows.Foundation;
    using Windows.Storage.Streams;
#endif


public class SocketButton : MonoBehaviour{

#if !UNITY_EDITOR
    StreamSocket socket;
#endif
	private string remoteIPAddress = "192.168.0.50";
	private int portNo = 1025;
	byte[] data;


    // Use this for initialization
    void Start()
    {
        iniSocket();
    }


    // Update is called once per frame
    void Update () {

    }

// public void iniSocket() {	}


    public void sendSocketMsg(int x) {
#if !UNITY_EDITOR
        try
        {
            DataWriter writer = new DataWriter(socket.OutputStream);
            writer.WriteString("action"+x+"\n");
            writer.StoreAsync();
        }
        catch (Exception e)
        {

        } 
#endif

    }

    private void iniSocket()
    {
#if !UNITY_EDITOR
        try
        {
            socket = new StreamSocket();
            socket.ConnectAsync(new HostName(remoteIPAddress), portNo.ToString());
        }
        catch (Exception e)
        {

        }
#endif
    }


    public static SocketButton instance;

    public static SocketButton GetInstance()
    {
        if(instance == null)
        {
            instance = new SocketButton();
        }
        return instance;
    }
}
