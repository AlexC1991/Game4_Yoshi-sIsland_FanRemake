using System;
using UnityEngine;
namespace AlexzanderCowell
{
    public class TileDestroyScript : MonoBehaviour
    {
        [Range(-1000,1000)] [SerializeField] private float xSize;
        [Range(-1000,1000)] [SerializeField] private float ySize;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Egg"))
            {
                gameObject.GetComponent<ParticleSystem>().Play();
                Destroy(gameObject, 0.2f);
            }
        }

        private void Update()
        {
            transform.localScale = new Vector3(xSize, ySize, 0f);
        }
    }
}
