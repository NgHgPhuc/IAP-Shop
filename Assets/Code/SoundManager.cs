using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public AudioSource SoundFx;
    public List<AudioClip> Meow;
    public AudioClip Open;
    public AudioClip Close;
    public AudioClip Drop;
    public AudioClip Buy;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMeow()
    {
        System.Random r = new System.Random();
        SoundFx.clip = Meow[r.Next(0, Meow.Count)];
        SoundFx.Play();
    }
    public void SoundFxPlay(AudioClip ac)
    {
        SoundFx.clip = ac;
        SoundFx.Play();
    }
}
