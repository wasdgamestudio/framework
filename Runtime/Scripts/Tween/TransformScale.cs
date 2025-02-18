using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScale : TickBehaviour
{
    [SerializeField] float Duration;
    [SerializeField] Vector3 StartScale = Vector3.one;
    [SerializeField] Vector3 TargetScale;
    [SerializeField] W_Ease Curve;
    [SerializeField] bool IsLocal;
    [SerializeField] int loops=-1;
    [SerializeField] W_LoopMode loopMode;

    protected override void Awake()
    {
        base.Awake();
        transform.Scale(TargetScale, Duration, Curve, loops, loopMode);
    }
}
