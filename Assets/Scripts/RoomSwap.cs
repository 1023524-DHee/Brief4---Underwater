using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwap : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            transform.position += new Vector3(0, 16f, 0f);
        }
	}
}
