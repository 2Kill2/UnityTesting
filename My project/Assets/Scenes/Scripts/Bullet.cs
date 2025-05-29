using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexScripts
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 20f;
        public float lifetime = 5f;
        private Rigidbody rb;


        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed;
            Destroy(gameObject, lifetime);
        }
    }
}
