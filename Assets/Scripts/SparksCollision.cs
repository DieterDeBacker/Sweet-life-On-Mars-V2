using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksCollision : MonoBehaviour
{
    [SerializeField]
    ParticleSystem sparks;
    void OnCollisionEnter(Collision other) {
        sparks.Play();
    }
}
