using System;
using UnityEngine;
namespace AlexzanderCowell
{
    public class SoundScript : MonoBehaviour
    {
        private AudioSource destinationSoundPlayer;
        [SerializeField] private AudioClip yoshiTongue;
        [SerializeField] private AudioClip yoshiRandomSound;
        [SerializeField] private AudioClip yoshiJump;
        private bool startJumpSound;
        
        public static bool playYoshiTongue;
        private bool randomYoshiSound;
        
        private float randomSoundTimer = 20;
        private float randomSoundTimerOrigina;


        private void Awake()
        {
            destinationSoundPlayer = GetComponent<AudioSource>();
        }

        private void Start()
        {
            playYoshiTongue = false;
            randomYoshiSound = true;
            randomSoundTimerOrigina = randomSoundTimer;
        }


        private void Update()
        {
            randomSoundTimer -= Time.deltaTime;

            if (randomSoundTimer <= 0.2f)
            {
                randomYoshiSound = true;
                randomSoundTimer = randomSoundTimerOrigina;
            }

            if (randomYoshiSound)
            {
                destinationSoundPlayer.loop = false;
                destinationSoundPlayer.clip = yoshiRandomSound;
                destinationSoundPlayer.Play();
                randomYoshiSound = false;
            }
            
            if (playYoshiTongue)
            {
                destinationSoundPlayer.loop = false;
                destinationSoundPlayer.clip = yoshiTongue;
                destinationSoundPlayer.Play();
                playYoshiTongue = false;
            }
            if (YoshiMovement.jumpingNow)
            {
                if (!destinationSoundPlayer.isPlaying)
                {
                    destinationSoundPlayer.clip = yoshiJump;
                    destinationSoundPlayer.Play();
                    destinationSoundPlayer.loop = true;
                }
                else if (destinationSoundPlayer.time >= 0.5f)
                {
                    destinationSoundPlayer.time = 0.3f;
                }
            }
            else if (!YoshiMovement.jumpingNow && YoshiMovement.isGrounded)
            {
                destinationSoundPlayer.loop = false;
            }
        }
    }
}
