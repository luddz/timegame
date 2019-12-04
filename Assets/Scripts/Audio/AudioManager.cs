using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;

    [SerializeField] private Sound[] sounds;
    [SerializeField] private float distanceCutOff; //Distance until sound cuts off completely

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

        Play("Theme");
        Play("Sandstorm");
    }

    void Start()
    {
        
    }

    public void PlayCloneSound(string name, Vector3 clonePos)
    {
        Vector3 playerPos = PlayerManager.Instance.transform.position;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        if (Vector3.Distance(playerPos,clonePos) < distanceCutOff)
        {
            float t = Vector3.Distance(playerPos, clonePos) / distanceCutOff;
            if (t < 0.0f || t > 1.0f)
                return;

            s.source.volume = Mathf.Lerp(1.0f, 0.0f, t) * s.cloneVolume;
            s.source.Play();
        }
        
    }        

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = s.playervolume;
        s.source.Play();
    }

    public void Play(string name, Vector3 originPos) {
        Vector3 playerPos = PlayerManager.Instance.transform.position;
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (Vector3.Distance(playerPos, originPos) < distanceCutOff) {
            float t = Vector3.Distance(playerPos, originPos) / distanceCutOff;
            if (t < 0.0f || t > 1.0f)
                return;

            s.source.volume = Mathf.Lerp(1.0f, 0.0f, t) * s.playervolume;
            s.source.Play();
        }
    }

    public void SetThemePitch(float pitch) {
        Sound s = Array.Find(sounds, sound => sound.name == "Theme");
        s.source.pitch = pitch;
    }

    public void InterpolateSandstorm(float t) {
        Sound s = Array.Find(sounds, sound => sound.name == "Sandstorm");
        s.source.volume = s.playervolume * t;
    }
    
}
