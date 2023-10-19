using UnityEngine;

namespace AlexzanderCowell
{
    public class ArrowFlash : MonoBehaviour
    {
        private float timer = 1f;
        private float originalTimer;

        private void Start()
        {
            originalTimer = timer;
        }

        void Update()
        {
            timer -= Time.deltaTime * 2;
            
            if (timer <= 0.2f)
            {
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else if (timer >= 0.3f)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (timer >= 0.4f)
            {
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else if (timer >= 0.5f)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (timer >= 0.6f)
            {
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else if (timer >= 0.7f)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (timer >= 0.8f)
            {
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else if (timer >= 0.9f)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }

            if (timer <= 0.1f)
            {
                timer = originalTimer;
            }

        }
    }
}