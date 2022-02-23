using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace SKhorozian.GPCW.Combat
{
    public class ProjectilePool : MonoSingleton<ProjectilePool>
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private List<Projectile> pool = new ();

        private void Start() {
            for (var i = 0; i < 15; i++) {
                var obj = Instantiate(projectilePrefab, Vector3.zero, quaternion.identity);
                
                obj.SetActive(false);
                
                pool.Add(obj.GetComponent<Projectile>());                
            }
        }

        public void RequestProjectileSpawn (Vector3 spawnPoint, Vector2 forceDir) {
            var projectile = pool[0];
            pool.Remove(projectile);
            
            projectile.Reinitialize(spawnPoint, forceDir);

            pool.Add(projectile);
        }

        public void ReadyForReuse(Projectile projectile) {
            if (pool.Contains(projectile)) pool.Remove(projectile);
            pool.Insert(0, projectile);
        }

    }
}