using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }
    public void StartPlaying()
    {
        aSource.Play();
    }

    public void StopPlaying()
    {
        aSource.Stop();
    }
}
