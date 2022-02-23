using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace SKhorozian.GPCW.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        
        [Space(10)]
        [SerializeField] private float forceMult = 20;
        [SerializeField] private float lifeTime = 5;
        
        public void Reinitialize(Vector3 newPos, Vector2 forceDir) {
            transform.position = newPos;

            gameObject.SetActive(true);

            rb.velocity = Vector3.zero;

            forceDir.Normalize();
            
            var force = new Vector3(forceDir.x, 0, forceDir.y) * forceMult;
            rb.AddForce(force, ForceMode.VelocityChange);
            
            StartCoroutine(DelayedDespawn());
        }

        private void OnCollisionEnter(Collision collision) {
            //Explode!

            Despawn();
        }

        private IEnumerator DelayedDespawn() {
            yield return new WaitForSeconds(lifeTime);
            Despawn();
        }

        private void Despawn() {
            StopAllCoroutines();
            ProjectilePool.instance.ReadyForReuse(this);
            gameObject.SetActive(false);
        }
    }
}