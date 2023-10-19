using UnityEngine;

namespace AlexzanderCowell
{
    public class YoshiAnimations : MonoBehaviour
    {
        
        private Animator yoshiAnimator;
        private bool startAttack;
        private float horizontalInput;
        
        
        private void Awake()
        {
            yoshiAnimator = GetComponent<Animator>();
        }

        private void Start()
        {
            yoshiAnimator.SetFloat("Blend", 0);
        }


        private void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                startAttack = true;
            }
            else
            {
                startAttack = false;
            }

            if (startAttack)
            {
                SoundScript.playYoshiTongue = true;
                yoshiAnimator.SetBool("Attack", true);
            }
            else
            {
                SoundScript.playYoshiTongue = false;
                yoshiAnimator.SetBool("Attack", false);
            }

            if (YoshiMovement.walkingNow && horizontalInput > 0 || horizontalInput < 0)
            {
                yoshiAnimator.SetFloat("Blend", 0.5f);
            }
            else if (YoshiMovement.walkingNow && horizontalInput == 0)
            {
                yoshiAnimator.SetFloat("Blend", 0);
            }
            else if (!YoshiMovement.walkingNow && YoshiMovement.runningNow && horizontalInput > 0 || horizontalInput < 0)
            {
                yoshiAnimator.SetFloat("Blend", 1);
            }

            if (YoshiMovement.jumpingNow)
            {
                yoshiAnimator.SetBool("Jump", true);
            }
            else if (!YoshiMovement.runningNow && YoshiMovement.isGrounded)
            {
                yoshiAnimator.playbackTime = 0;
                yoshiAnimator.SetBool("Jump", false);
            }
        }
    }
}
