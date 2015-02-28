using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OscMessageHandlerScript : MonoBehaviour
{
	public string remoteIP = "127.0.0.1";
	public int listeningPort = 7000;

	private Osc _handler;
	private Dictionary<string, OscListenerScript> _listeners;

	private static OscMessageHandlerScript _mainHandler;
	public static OscMessageHandlerScript mainHandler
	{
		get
		{
			return _mainHandler;
		}
	}

	public void AddListener(OscListenerScript listener, string address)
	{
		_listeners.Add(address, listener);
	}

	private void AllMessageHandler(OscMessage oscMessage)
	{
		string msgAddress = oscMessage.Address;

		if (_listeners.ContainsKey(msgAddress))
		{
			_listeners[msgAddress].ReceiveOscMessage(oscMessage.Values);
		}
		else
		{
			Debug.LogWarning("Received unexpected message: " + Osc.OscMessageToString(oscMessage));
		}
	}
	
	void Start()
	{
		_mainHandler = this;

		_listeners = new Dictionary<string,OscListenerScript>();

		// init OSC packet receiver
		UDPPacketIO udp = GetComponent<UDPPacketIO>();
		udp.init(remoteIP, 0, listeningPort);
		_handler = GetComponent<Osc>();
		_handler.init(udp);
		_handler.SetAllMessageHandler(AllMessageHandler);
	}
}
