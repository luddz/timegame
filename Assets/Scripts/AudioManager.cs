using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;

    [SerializeField] private Sound[] sounds;


    public static AudioManager Instance { get { return instance; } }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.playervolume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
        } 
    }

    void Start()
    {
        //Play("Theme");
    }

    public void PlayCloneSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = s.cloneVolume;
        s.source.Play();
    }        

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = s.playervolume;
        s.source.Play();
    }
    
}
