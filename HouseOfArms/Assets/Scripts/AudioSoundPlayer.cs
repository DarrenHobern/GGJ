using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSoundPlayer : MonoBehaviour
{
    public AudioClip Yay1;
    public AudioClip Yay2;
    public AudioClip Hiss;
    public AudioClip Ching;

    public void PlaySoundYay1()
    {
        GetComponent<AudioSource>().clip = Yay1;
        GetComponent<AudioSource>().Play();
    }

    public void PlaySoundYay2()
    {
        GetComponent<AudioSource>().clip = Yay2;
        GetComponent<AudioSource>().Play();
    }

    public void PlaySoundHiss()
    {
        GetComponent<AudioSource>().clip = Hiss;
        GetComponent<AudioSource>().Play();
    }

    public void PlaySoundChing()
    {
        GetComponent<AudioSource>().clip = Ching;
        GetComponent<AudioSource>().Play();
    }
}
