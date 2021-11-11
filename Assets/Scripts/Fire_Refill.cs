using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Refill : MonoBehaviour
{
    public float refillAmount;

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            IRefill refillable = collision.GetComponent<IRefill>();
            if (refillable != null)
            {
                refillable.StartRefill(refillAmount);
            }
        }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            IRefill refillable = collision.GetComponent<IRefill>();
            if (refillable != null)
            {
                refillable.StopRefill();
            }
        }
    }
}
