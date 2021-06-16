using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{

    Animator myAnim;

    [SerializeField] float waitTime;
    [SerializeField] float Speed;
    [SerializeField] [Range(0,1)] float animationOffset;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myAnim.SetFloat("WaitTime", waitTime);
        myAnim.SetFloat("Speed", Speed);
        myAnim.Play("WaitTime", -1, animationOffset);
    }
    void OnValidate()
     {
         myAnim.SetFloat("WaitTime", waitTime);
        myAnim.SetFloat("Speed", Speed);
     }
}
