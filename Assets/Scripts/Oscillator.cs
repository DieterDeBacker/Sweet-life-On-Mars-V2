using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Oscillator : MonoBehaviour
{


    [SerializeField]
    float y;
    [SerializeField]
    float duration;
    [SerializeField]
    float timeOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        startTween();
    }

    // Update is called once per frame
    void startTween(){
        Vector3 startingPos = transform.position;    
        float endPos = startingPos.y + y;
        transform.DOMoveY(endPos, duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(timeOffset)
            .SetEase(Ease.InCubic);

    }
}
