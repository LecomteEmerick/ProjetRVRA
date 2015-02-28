using UnityEngine;

public abstract class OscListenerScript
{
	[SerializeField]
	private string _oscAddress;	// Osc Address we want to listen to

	public abstract void ReceiveOscMessage(ArrayList values);

	private void RegisterOscListener()
	{
		OscMessageHandlerScript.mainHandler.AddListener(this, _oscAddress);
	}

	void Start()
	{
		RegisterOscListener();
	}
}
