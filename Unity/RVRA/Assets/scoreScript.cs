using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class scoreScript : MonoBehaviour {

    public string name;

    [SerializeField]
    private UnityEvent winGameEvent;

    private int _myScore;

	// Use this for initialization
	void Start () {
	}

    public void initializeScore()
    {
        _myScore = 0;
    }

    public void increaseScore()
    {
        _myScore += 1;
        Debug.Log(name + " a : " + _myScore + " points");
        if (_myScore > 9)
            winGameEvent.Invoke();
    }
}
