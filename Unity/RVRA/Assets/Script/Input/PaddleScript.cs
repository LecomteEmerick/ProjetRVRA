using UnityEngine;
using System.Collections;

public class PaddleScript : OscListenerScript
{
	[SerializeField]
	private Transform _transform;

	private Vector2 _targetPos = Vector2.zero;

	public override void ReceiveOscMessage(ArrayList values)
	{
		_targetPos = new Vector2(((float)values[0] - 0.5f) * 2.0f, ((float)values[1] - 0.5f) * 2.0f);
	}

	void FixedUpdate()
	{
		float widthFactor = Camera.main.orthographicSize * Camera.main.aspect;
		float heightFactor = 2.0f * Camera.main.orthographicSize / Camera.main.aspect;
		Vector3 newPos = new Vector3(- _targetPos.y * heightFactor, _transform.position.y, _targetPos.x * widthFactor);
		Vector3 diff = newPos - _transform.position;
		if (diff.magnitude > 0.5f)
		{
			Quaternion newAng = Quaternion.LookRotation(newPos - _transform.position);

			// TODO: Apply force towards the new position and rotation
			_transform.position = newPos;
			_transform.rotation = newAng;
		}
	}
}
