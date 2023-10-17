using UnityEngine;

namespace AlexzanderCowell
{
    public class YoshiAnimations : MonoBehaviour
    {
        
        private Animator yoshiAnimator;
        private bool startAttack;
        
        
        private void Awake()
        {
            yoshiAnimator = GetComponent<Animator>();
        }


        private void Update()
        {
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
                yoshiAnimator.SetBool("Attack", true);
            }
            else
            {
                yoshiAnimator.SetBool("Attack", false);
            }
        }
    }
}
