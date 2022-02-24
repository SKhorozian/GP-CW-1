using SKhorozian.GPCW.Combat;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace SKhorozian.GPCW.AI
{
    public class AttackState : State
    {
        private const float ChaseDistance = 15f;
        private const float StopDistance = 10f;
        private const float Speed = 5f;
        private const float FlockAvoidance = 2f;
        private readonly LayerMask _playerLayer = 1 << 8;
        private readonly LayerMask _enemyLayer = 1 << 9;
        
        private Transform _playerTransform;
        private StateMachine _machine;
            
            
        private float attackTimer;
        
        public AttackState(Transform playerTransform, StateMachine machine) {
            _playerTransform = playerTransform;
            _machine = machine;
            
            _machine.Agent.speed = Speed;

            attackTimer = Random.Range(2f, 4f);
        }
        
        public override State PerformState() {
            if (!CanSeePlayer()) return new PatrolState(_playerTransform, _machine);

            var flockDirection = Flocking();
            OrbitPlayer(flockDirection);

            if (attackTimer > 0) attackTimer -= Time.deltaTime;
            else FireAttack();
            
            return this;
        }
        
        //Not square rooting distance for efficiency :P
        private float GetDistanceFromPlayer() => Mathf.Pow(_playerTransform.position.x - _machine.transform.position.x, 2) + Mathf.Pow(_playerTransform.position.z - _machine.transform.position.z, 2);

        private void OrbitPlayer(Vector3 flockDirection) {
            var distanceFromPlayer = GetDistanceFromPlayer();

            var direction = Vector3.zero;
            
            if (distanceFromPlayer < Mathf.Pow(StopDistance - 1f, 2)) 
                direction = _machine.transform.position - _playerTransform.position;
            else if (distanceFromPlayer < Mathf.Pow(StopDistance - 0.5f, 2))
                direction = Vector3.zero;
            else  
                direction = _playerTransform.position - _machine.transform.position;
            
            direction = flockDirection + direction.normalized;
            direction.Normalize();

            _machine.Agent.destination = _machine.transform.position + (direction * 8);
            _machine.transform.LookAt(_playerTransform);
        }

        private Vector3 Flocking() {
            var ray = new Ray(_machine.transform.position, Vector3.up);
            var hits = Physics.SphereCastAll(ray, FlockAvoidance, 0.1f);
            
            var directions = Vector3.zero;

            foreach (var hit in hits) {
                if (!hit.transform.CompareTag("Enemy")) continue;
                if (hit.transform.Equals(_machine.transform)) continue;

                var direction = _machine.transform.position - hit.transform.position;
                direction.Normalize();

                directions += direction;
            }

            directions.Normalize();

            return directions;
        }

        private bool CanSeePlayer() {
            var machinePosition = _machine.transform.position;
            var direction = _playerTransform.position - machinePosition;
            direction.Normalize();

            var ray = new Ray(machinePosition, direction);

            return Physics.Raycast(ray, out var hit, ChaseDistance, _playerLayer) && hit.transform.CompareTag("Player");
        }

        private void FireAttack() {
            var machinePosition = _machine.transform.position;
            var direction = _playerTransform.position - machinePosition;
            direction.Normalize();
            
            var ray = new Ray(machinePosition, direction);

            if (Physics.SphereCast(ray, 1f, out var hit)) 
                if (!hit.transform.CompareTag("Player")) {
                    attackTimer = 1f;
                    return;   
                }
            

            var direction2D = new Vector2(direction.x, direction.z);
            var firePoint = _machine.transform.position + direction * 1.5f;

            ProjectilePool.instance.RequestProjectileSpawn(firePoint, direction2D);

            _machine.ParticleSystem.Play();
            _machine.AudioSource.Play();
            
            attackTimer = Random.Range(1f, 2.5f);
        }
    }
}