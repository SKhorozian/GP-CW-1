using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace SKhorozian.GPCW.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Collider collider;
        
        [Space(10)]
        [SerializeField] private float forceMult = 20;
        [SerializeField] private float lifeTime = 5;

        [SerializeField] private LayerMask hitLayers;
        
        //Visuals
        [Space(10)] 
        [SerializeField] private GameObject ball;
        [SerializeField] private ParticleSystem explosion;
        [SerializeField] private ParticleSystem trail;

        [Space(10)] 
        [SerializeField] private AudioSource explosionSFX;

        private void Start() {
            ball.SetActive(false);
            rb.isKinematic = true;
            collider.enabled = false;
        }

        public void Reinitialize(Vector3 newPos, Vector2 forceDir) {
            transform.position = newPos;

            ball.SetActive(true);
            rb.isKinematic = false;
            collider.enabled = true;
            trail.Stop();
            trail.Play();
            
            rb.velocity = Vector3.zero;

            forceDir.Normalize();
            
            var force = new Vector3(forceDir.x, 0, forceDir.y) * forceMult;
            rb.AddForce(force, ForceMode.VelocityChange);
            
            StartCoroutine(DelayedDespawn());
        }

        private void OnCollisionEnter(Collision collision) {
            var hits = Physics.SphereCastAll(transform.position, 1.5f, Vector3.up, 0.1f, hitLayers);

            foreach (var hit in hits) {
                if (hit.transform.CompareTag("Enemy")) Destroy(hit.transform.gameObject);

                if (hit.transform.CompareTag("Player")) 
                   hit.transform.GetComponent<CharacterHealth>().TakeDamage();
            }
            
            explosionSFX.Play();
            
            Despawn();
            
            explosion.Play();
        }

        private IEnumerator DelayedDespawn() {
            yield return new WaitForSeconds(lifeTime);
            Despawn();
        }

        private void Despawn() {
            StopAllCoroutines();
            
            ball.SetActive(false);
            rb.isKinematic = true;
            collider.enabled = false;
        }
    }
}