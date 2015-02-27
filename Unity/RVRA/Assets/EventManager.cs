using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {

    
    public UnityEvent startGameEvent;
    public UnityEvent newRoundEvent;
    public UnityEvent endGameEvent;
    public UnityEvent increasePointEvent;
    public UnityEvent scoreGoalEvent;


	void Start () {
        fireStartGameEvent();
	}

    public void fireGoalEvent()
    {
        Debug.Log("Goal!");
        if (scoreGoalEvent != null)
            scoreGoalEvent.Invoke();
    }

    public void fireEndGameEvent()
    {
        Debug.Log("Winner");
        if (endGameEvent != null)
            endGameEvent.Invoke();
    }

    public void fireStartGameEvent()
    {
        Debug.Log("New Game");
        if (startGameEvent != null)
            startGameEvent.Invoke();
    }

    public void fireNewRoundEvent()
    {
        Debug.Log("New round");
        if (newRoundEvent != null)
            newRoundEvent.Invoke();
    }
}
