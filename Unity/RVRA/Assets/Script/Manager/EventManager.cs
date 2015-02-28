using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {

    
    public UnityEvent startGameEvent;
    public UnityEvent newRoundEvent;
    public UnityEvent endGameEvent;
    public UnityEvent increasePointEvent;
    public UnityEvent scoreGoalEvent;
    public UnityEvent playerOneGoalEvent;
    public UnityEvent playerTwoGoalEvent;
    public UnityEvent playerOneWinEvent;
    public UnityEvent playerTwoWinEvent;


	void Start () {
        fireStartGameEvent();
	}

    public void firePlayerOneWinEvent()
    {
        Debug.Log("Player One win");
        if (playerOneWinEvent != null)
            playerOneWinEvent.Invoke();
        fireEndGameEvent();
    }

    public void firePlayerTwoWinEvent()
    {
        Debug.Log("Player two win");
        if (playerOneWinEvent != null)
            playerOneWinEvent.Invoke();
        fireEndGameEvent();
    }

    public void firePlayerOneGoalEvent()
    {
        //Debug.Log("Player One Goal");
        if (playerTwoWinEvent != null)
            playerTwoWinEvent.Invoke();
        fireGoalEvent();
    }

    public void firePlayerTwoGoalEvent()
    {
        //Debug.Log("Player Two Goal");
        if (playerTwoGoalEvent != null)
            playerTwoGoalEvent.Invoke();
        fireGoalEvent();
    }

    public void fireGoalEvent()
    {
        //Debug.Log("Goal!");
        if (scoreGoalEvent != null)
            scoreGoalEvent.Invoke();
    }

    public void fireEndGameEvent()
    {
        //Debug.Log("End Game");
        if (endGameEvent != null)
            endGameEvent.Invoke();
    }

    public void fireStartGameEvent()
    {
        //Debug.Log("New Game");
        if (startGameEvent != null)
            startGameEvent.Invoke();
    }

    public void fireNewRoundEvent()
    {
        //Debug.Log("New round");
        if (newRoundEvent != null)
            newRoundEvent.Invoke();
    }

    public void fireIncreasePointEvent()
    {
        //Debug.Log("Score increase");
        if (increasePointEvent != null)
            increasePointEvent.Invoke();
    }
}
