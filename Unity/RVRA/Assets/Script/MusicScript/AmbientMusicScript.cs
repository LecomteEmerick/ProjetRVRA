using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmbientMusicScript : MonoBehaviour {

    public AudioSource mySource;
    public List<AudioClip> deathUnitAudio;

    void Start()
    {
        StartCoroutine(takeRadomDeathUnit(0));
    }

    public void playRandomDeathUnitAudio()
    {
        if (mySource.clip.isReadyToPlay)
        {
            mySource.Play();
            StartCoroutine(takeRadomDeathUnit(3));
        }
    }

    private IEnumerator takeRadomDeathUnit(int second)
    {
        yield return new WaitForSeconds(second);
        int random = (int)(Random.value * deathUnitAudio.Count);
        if (random == 3)
            random--;
        mySource.clip = deathUnitAudio[random];
    }
}
