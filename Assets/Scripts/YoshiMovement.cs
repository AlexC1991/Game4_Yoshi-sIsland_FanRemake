using System;
using UnityEngine;
namespace AlexzanderCowell
{
    public class YoshiMovement : MonoBehaviour
    {
        [Range(0, 10)]
        [SerializeField] private float moveSpeed;
        [Range(0, 20)]
        [SerializeField] private float runSpeed;
        [Range(0, 50)]
        [SerializeField] private float jumpHeight;
        [Range(-50, 50)]
        [SerializeField] private float gravity;
        private float horizontalMovement;
        private float verticalMovement;
        private bool runningNow;
        private bool jumpingNow;
        private float moveSpeedOriginal;
        private Rigidbody2D rb2D;
        private int jumpCount;
        private LayerMask groundLayer;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            moveSpeedOriginal = moveSpeed;
        }
        
        private void Update()
        {
            rb2D.gravityScale = gravity;
            horizontalMovement = Input.GetAxis("Horizontal");
            verticalMovement = Input.GetAxis("Vertical");
            PlayerMovement();
            PlayerJump();
        }

        private void PlayerMovement()
        {
            if (horizontalMovement > 0)
            {
                transform.Translate(Vector3.right * (horizontalMovement * moveSpeed * Time.deltaTime));
            }
            else if (horizontalMovement < 0)
            {
                transform.Translate(Vector3.left * (-horizontalMovement * moveSpeed * Time.deltaTime));
            }
            
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                runningNow = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                runningNow = false;
            }

            if (runningNow)
            {
                moveSpeed = runSpeed;
            }
            else if (!runningNow)
            {
                moveSpeed = moveSpeedOriginal;
            }
        }
        
        private void PlayerJump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpingNow = true;
                jumpCount += 2;
            }
            else if (jumpCount == 1 || Input.GetKeyUp(KeyCode.Space))
            {
                jumpingNow = false;
                jumpCount = 0;
            }

            if (jumpingNow)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
            }
        }
    }
}
