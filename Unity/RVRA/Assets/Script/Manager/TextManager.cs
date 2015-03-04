using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {

    public TextMesh DisplayedText;

    private bool _playerWin = false;

    public void setPlayerWin(string name)
    {
        _playerWin = true;
        DisplayedText.text = name + " a gagné !";
        StartCoroutine(setValueAfterSeconde(5,""));
        StartCoroutine(setPlayerWinToFalse(5));
    }

    private IEnumerator setValueAfterSeconde(int seconde, string value)
    {
        yield return new WaitForSeconds(seconde);
        DisplayedText.text = value;
    }

    private IEnumerator setPlayerWinToFalse(int second)
    {
        yield return new WaitForSeconds(second);
        _playerWin = false;
    }

    public void displayCouldown(int number)
    {
        if (_playerWin) { return; }
        int secondTime = 0;
        for(int i=number; i > 0;i--)
        {
            StartCoroutine(setValueAfterSeconde(secondTime, i.ToString()));
            secondTime += 1;
        }
        StartCoroutine(setValueAfterSeconde(secondTime, "Go!"));
        secondTime += 1;
        StartCoroutine(setValueAfterSeconde(secondTime, ""));
    }
}
