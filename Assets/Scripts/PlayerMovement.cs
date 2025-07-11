using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    public Transform groundCheck;
    [SerializeField] float groundCheckRadius= 0.2f;
    public LayerMask layerMask;
    public bool isFinish = false;

    public Rigidbody2D rb;
    [SerializeField] bool isGrounded;
    [SerializeField] float moveInput;

    [SerializeField] int playerHealth = 10;
    public TMP_Text healthUI;
    [SerializeField] bool isDamaged = false;

    public GameObject restartUI;
    public bool isPlayerOn;

    // to set sprite die
    public SpriteRenderer charaSprite;
    public Sprite charaImage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();

        playerJump();

        if(playerHealth <= 0)
        {
            DieAnimation(); //memanggil method die animation
            Invoke("ResetLevel", 2f); // setelah 2 detik dia bakal memanggil Reset Level Method dengan invoke 
         
            //restartUI.SetActive(true);
            
        }

        healthUI.text = "Health : " + playerHealth.ToString();
    }

    public void ResetLevel()
    {
        this.gameObject.SetActive(false);
        restartUI.SetActive(true);
    }

    public void DieAnimation()
    {
        moveSpeed = 0f;
        jumpForce = 0f;
        charaSprite.sprite = charaImage;
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !isDamaged)
        {
            playerHealth -= 1;
            isDamaged = true;
        }
        else
        {
            Debug.Log("Tidak kena damage");
        }

        if (collision.gameObject.CompareTag("Border"))
        {
            playerHealth = 0;
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && isDamaged)
        {
            isDamaged = false;
        }
        else
        {
            Debug.Log("kena damage");
        }
    }


    void playerMove()
    {
        if (isPlayerOn)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
        }

    }

    void playerJump()
    {
        if (isPlayerOn)
        {
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, layerMask);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
