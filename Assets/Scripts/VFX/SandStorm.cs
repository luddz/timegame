using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandStorm : MonoBehaviour {

    private ParticleSystem particleSystem;
    private ParticleSystem secondaryParticleSystem;

    void Awake() {
        particleSystem = GetComponent<ParticleSystem>();
        secondaryParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    public void StopStorm() {
        particleSystem.Stop();
        secondaryParticleSystem.Stop();
    }

    public void StartStorm() {
        particleSystem.Play();
        secondaryParticleSystem.Play();
    }
}
