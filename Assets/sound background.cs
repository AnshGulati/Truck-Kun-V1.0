using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundbackground : MonoBehaviour
{
    public double musicDuration;
    public double goaltime;

    public AudioClip currentclip;
    public AudioSource audioSource;
    public AudioSource[] _audioSources;    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AudioSettings.dspTime > goaltime - 1)
        {
            PlayScheduledClip();
        }
    }
    private void OnPlayMusic()
    {
        goaltime = AudioSettings.dspTime + 0.5;
        audioSource.clip = currentclip;
        audioSource.PlayScheduled(goaltime);

        musicDuration = (double)currentclip.samples / currentclip.frequency;
        goaltime = goaltime + musicDuration;
        
    }
    private void PlayScheduledClip()
    {

    }
}
