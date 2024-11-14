using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMan : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public AudioClip bg;
    private void Start()
    {
        musicSource.clip = bg;
        musicSource.Play();
    }
}
