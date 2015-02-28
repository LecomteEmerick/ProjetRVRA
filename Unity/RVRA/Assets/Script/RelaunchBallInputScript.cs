using UnityEngine;
using System.Collections;

public class RelaunchBallInputScript : MonoBehaviour {

    public ballManagerScript script;

	void Update () {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            script.LaunchBall();
        }
	}
}
