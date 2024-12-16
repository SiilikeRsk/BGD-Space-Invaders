using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
               
        audioSource.loop = true;
        audioSource.volume = 0.5f; 
    }
    public IEnumerator FadeOut()
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= Time.deltaTime * 0.5f; // Adjust fade speed
            yield return null;
        }
        audioSource.Stop();
    }

    public IEnumerator FadeIn(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.volume = 0;
        while (audioSource.volume < 0.5f)
        {
            audioSource.volume += Time.deltaTime * 0.5f; // Adjust fade speed
            yield return null;
        }
    }

    public void PlayMusic1()
    {
        PlayMusic(music1);
    }

    public void PlayMusic2()
    {
        PlayMusic(music2);
    }

    public void PlayMusic3()
    {
        PlayMusic(music3);
    }

    public void PlayMusic4()
    {
        PlayMusic(music4);
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    private void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No AudioClip assigned!");
        }
    }
}
