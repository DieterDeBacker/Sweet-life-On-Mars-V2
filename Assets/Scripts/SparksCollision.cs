using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksCollision : MonoBehaviour
{
    [SerializeField]
    ParticleSystem sparks;

    [SerializeField] AudioClip thomperSlam;

    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) {
        sparks.Play();
        // TODO:: Something with 3D sound
        //aSource.PlayOneShot(thomperSlam, 0.1f);
    }
}
