using System;
using UnityEngine;
namespace AlexzanderCowell
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 pointA;
        [SerializeField] private Vector2 pointB;
        [SerializeField] private float speed = 1f;
        private Rigidbody2D rigidb2D;

        private void Awake()
        {
            rigidb2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time * speed, 1));
            Vector2 currentPosition = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time * speed, 1));
            
            // Calculate the direction to pointA and pointB
            Vector2 directionToA = (pointA - currentPosition).normalized;
            Vector2 directionToB = (pointB - currentPosition).normalized;
            
            Debug.Log(Vector2.Dot(directionToA, currentPosition - pointA) > 0);
            
             // Determine which direction the character is moving towards
            if (Vector2.Dot(directionToA, currentPosition - pointA) > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
