using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {

    public string name;

    public Text uiDisplayScore;
    public Text uiDisplayCurrentPoint;

    [SerializeField]
    private UnityEvent winGameEvent;

    [SerializeField]
    private int numberPointForWin = 10;

    private int _myScore;
    private int _currentPoint;

    public void initializeScore()
    {
        _myScore = 0;
        uiDisplayScore.text = _myScore.ToString();
        resetCurrentPoint();
    }

    public void resetCurrentPoint()
    {
        _currentPoint = 1;
        uiDisplayCurrentPoint.text = _currentPoint.ToString();
    }

    public void increaseCurrentPoint()
    {
        _currentPoint++;
        uiDisplayCurrentPoint.text = _currentPoint.ToString();
    }

    public void increaseScore()
    {
        _myScore += _currentPoint;
        uiDisplayScore.text = _myScore.ToString();
        //Debug.Log(name + " a : " + _myScore + " points");
        if (_myScore >= numberPointForWin)
            winGameEvent.Invoke();
    }
}
