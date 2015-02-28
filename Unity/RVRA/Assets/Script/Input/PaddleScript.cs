using UnityEngine;
using System.Collections;

public class PaddleScript : OscListenerScript
{
	[SerializeField]
	private Transform _transform;

	public override void ReceiveOscMessage(ArrayList values)
	{
		Vector3 newPos = new Vector3((float)values[0], _transform.position.y, (float)values[1]);
		Quaternion newAng = Quaternion.LookRotation(newPos - _transform.position);

		// Temporary
		_transform.position = newPos;
		_transform.rotation = newAng;
	}
}
