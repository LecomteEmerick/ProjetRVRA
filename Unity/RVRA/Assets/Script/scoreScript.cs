using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class scoreScript : MonoBehaviour {

    public string name;

    [SerializeField]
    private UnityEvent winGameEvent;

    [SerializeField]
    private int numberPointForWin = 10;

    private int _myScore;
    private int _currentPoint;

    public void initializeScore()
    {
        _myScore = 0;
        resetCurrentPoint();
    }

    public void resetCurrentPoint()
    {
        _currentPoint = 1;
    }

    public void increaseCurrentPoint()
    {
        _currentPoint++;
    }

    public void increaseScore()
    {
        _myScore += _currentPoint;
        Debug.Log(name + " a : " + _myScore + " points");
        if (_myScore >= numberPointForWin)
            winGameEvent.Invoke();
    }
}
