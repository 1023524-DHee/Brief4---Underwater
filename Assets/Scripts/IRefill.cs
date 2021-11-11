using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRefill
{
    void StartRefill(float refillAmount);
    void StopRefill();
}
