using UnityEngine;
using UnityEngine.UI;

namespace AlexzanderCowell
{
    public class ThrowingEggScript : MonoBehaviour
    {
        [SerializeField] private GameObject eggPrefab;
        [SerializeField] private float eggThrowForce = 3f;
        [SerializeField] private GameObject aimA;
        private bool startThrowingEgg;
        private bool releaseEgg;
        public static int throwingSequence;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                throwingSequence = 1;
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                throwingSequence = 2;
                releaseEgg = true;
            }

            if (throwingSequence == 0)
            {
                aimA.SetActive(false);
            }
            else if (throwingSequence == 1)
            {
                aimA.SetActive(true);
            }

            if (releaseEgg)
            {
                ThrowEgg();
            }
        }

        private void ThrowEgg()
        {
            Vector2 throwDirection = new Vector2(Mathf.Cos(aimA.transform.position.y * Mathf.Deg2Rad), 
                Mathf.Sin(aimA.transform.eulerAngles.z * Mathf.Deg2Rad));
            GameObject egg = Instantiate(eggPrefab, aimA.transform.position, Quaternion.identity);
            Rigidbody2D eggRigidbody = egg.GetComponent<Rigidbody2D>();
            if (aimA.GetComponent<SpriteRenderer>().flipX)
            {
                eggRigidbody.AddForce(-throwDirection * eggThrowForce, ForceMode2D.Impulse);
            }
            else if (!aimA.GetComponent<SpriteRenderer>().flipX)
            {
                eggRigidbody.AddForce(throwDirection * eggThrowForce, ForceMode2D.Impulse);
            }
            releaseEgg = false;
            throwingSequence = 0;
        }


    }
}
