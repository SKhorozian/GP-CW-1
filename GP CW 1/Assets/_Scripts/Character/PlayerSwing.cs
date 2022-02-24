using System;
using UnityEngine;

namespace SKhorozian.GPCW.Combat
{
    public class PlayerSwing : MonoBehaviour
    {
        [SerializeField] private Transform swingPoint;
        [SerializeField] private LayerMask projectileLayer;
        
        [SerializeField] private float swingCooldown = 0.75f;
        [SerializeField] private float timer = 0;

        [SerializeField] private float forceMult;
        
        [Space(10)]
        [SerializeField] private ParticleSystem hitEffect;
        [SerializeField] private Animator animator;
        
        [Space(10)]
        [SerializeField] private AudioSource swingAudioSource;
        [SerializeField] private AudioSource hitAudioSource;
        
        private void Update() {
            timer -= Time.deltaTime;
            timer = Mathf.Clamp(timer, 0, swingCooldown);

        }

        public void Swing() {
            if (timer > 0) return;

            var projectiles = Physics.SphereCastAll(swingPoint.position, 2, Vector3.up, 0.1f, projectileLayer);

            foreach (var projectile in  projectiles) {
                var rb = projectile.transform.GetComponent<Rigidbody>();
                
                rb.velocity = Vector3.zero;
                rb.AddForce(swingPoint.forward * forceMult, ForceMode.VelocityChange);
            }
            
            if (projectiles.Length > 0) {
                hitEffect.Play();
                hitAudioSource.Play();
            }
            
            animator.Play("batSwing");
            swingAudioSource.Play();

            timer = swingCooldown;
        }


    }
}