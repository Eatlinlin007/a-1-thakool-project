using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovingPlatform
{
    float Speed { get; set; }
    int StartingPoint { get; set; }
    Transform[] Points { get; set; }
    void Moving();
    void AttachToPlatform(Transform transform);
    void DetachFromPlatform(Transform transform);
}
