using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float amount;

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            IPickup pickupable = collision.GetComponent<IPickup>();
            if (pickupable != null)
            {
                pickupable.GainMoney(amount);
            }
            transform.position += new Vector3(0f, 16f, 0f);
        }
	}
}
