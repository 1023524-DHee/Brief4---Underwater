using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Movement : MonoBehaviour, IRefill, IPickup
{
    private Rigidbody2D playerRB;
    public Animator playerAnimator;
    public Image fireBar;
    public TMP_Text moneyUI;

    // MOVEMENT
    private float movementDirection;
    private int facingDirection = 1;
    private bool isGrounded = true;

    // FIRE
    private float fireAmount = 100f;
    public float depleteAmount = 5f;
    private bool isFilling;
    private float refillAmount;

    // CURRENCY
    private float moneyAmount;

    public float moveSpeed;
    public float jumpVelocity;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckJump();
        CheckGrounded();
        Flip();

        Refill();
        FireDeplete();

        UpdateAnimation();
    }

	private void FixedUpdate()
	{
        CheckMovementInput();
    }

	private void CheckMovementInput()
    {
        movementDirection = Input.GetAxisRaw("Horizontal");
        playerRB.velocity = new Vector2(movementDirection * moveSpeed, playerRB.velocity.y);
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpVelocity);
        }
    }

    private void CheckGrounded()
    {
        if (playerRB.velocity.y <= 0.01)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void Flip()
    {
        if (facingDirection == 1 && movementDirection < 0)
        {
            transform.Rotate(0, 180f, 0);
            facingDirection = -1;
        }
        else if (facingDirection == -1 && movementDirection > 0)
        {
            transform.Rotate(0, 180f, 0);
            facingDirection = 1;
        }
    }

    private void FireDeplete()
    {
        if (!isFilling)
        {
            fireAmount -= depleteAmount * Time.deltaTime;
        }
        fireBar.fillAmount = fireAmount / 100f;
    }

	public void StartRefill(float refillAmount)
	{
        isFilling = true;
        this.refillAmount = refillAmount;
    }

	public void StopRefill()
	{
        isFilling = false;
	}

    public void Refill()
    {
        if (isFilling)
        {
            fireAmount += refillAmount * Time.deltaTime;
            if (fireAmount > 100)
            {
                fireAmount = 100;
            }
        }
    }

	public void GainMoney(float amount)
	{
        moneyAmount += amount;
        moneyUI.text = "" + moneyAmount;
	}

    public void UpdateAnimation()
    {
        if (playerRB.velocity.x == 0) playerAnimator.SetBool("IsWalking", false);
        else if(playerRB.velocity.x != 0) playerAnimator.SetBool("IsWalking", true);
    }
}
