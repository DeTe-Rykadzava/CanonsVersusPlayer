using System;
using Interfaces;
using UnityEngine;

namespace CanonScripts
{
    public class CanonBullet : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Rigidbody rb;

        private bool _rbIsNull;
        
        private void Awake()
        {
            _rbIsNull = rb == null;
        }


        public void AddForce(Vector3 force)
        {
            if(_rbIsNull) return;
            rb.AddForce(force, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }
    }
}