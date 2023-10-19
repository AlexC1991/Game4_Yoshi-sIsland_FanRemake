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
        public static bool runningNow;
        public static bool jumpingNow;
        private float moveSpeedOriginal;
        private Rigidbody2D rb2D;
        private float jumpCount;
        [SerializeField] private LayerMask groundLayer;
        public static bool walkingNow;
        public static bool isGrounded;
        [SerializeField] private float groundDetectionRadius = 5f;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            moveSpeedOriginal = moveSpeed;
            walkingNow = true;
        }
        
        private void Update()
        {
            Debug.Log("Is Yoshi Grounded ? " + isGrounded);
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
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                transform.Translate(Vector3.right * (horizontalMovement * moveSpeed * Time.deltaTime));
            }
            else if (horizontalMovement < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
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
                walkingNow = false;
                moveSpeed = runSpeed;
            }
            else if (!runningNow)
            {
                walkingNow = true;
                moveSpeed = moveSpeedOriginal;
            }
        }
        
        private void PlayerJump()
        {

            isGrounded = Physics2D.OverlapCircle(transform.position, groundDetectionRadius, groundLayer);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                jumpingNow = true;
            }
            else if (jumpCount >= 3 || Input.GetKeyUp(KeyCode.Space))
            {
                jumpingNow = false;
                rb2D.velocity = new Vector2(-rb2D.velocity.x, jumpHeight);
                jumpCount = 0;
            }

            if (jumpingNow)
            {
                jumpCount += 4 * Time.deltaTime;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, groundDetectionRadius);
        }

    }
}
