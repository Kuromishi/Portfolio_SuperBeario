using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    public Transform m_endPos;
    public float m_duration;
    // Start is called before the first frame update
    void Start()
    {
        Tweener tween = transform.DOMove(m_endPos.position, m_duration );
        tween.SetLoops(-1, LoopType.Yoyo);
        tween.SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
