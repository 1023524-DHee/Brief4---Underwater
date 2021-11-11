using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtons : MonoBehaviour
{
    public Player_Movement playerMovement;

    public void SpeedUpgrade()
    {
        playerMovement.moveSpeed *= 1.3f;
    }

    public void JumpUpgrade()
    {
        playerMovement.jumpVelocity *= 1.3f;
    }

    public void TorchUpgrade()
    {
        playerMovement.depleteAmount *= 0.9f;
    }
}
