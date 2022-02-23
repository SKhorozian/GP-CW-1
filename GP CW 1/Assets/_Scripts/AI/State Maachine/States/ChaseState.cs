using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace SKhorozian.GPCW.AI
{
    public class ChaseState : State
    {
        private const float ChaseDistance = 12.5f;
        private const float StopDistance = 8f;
        private const float Speed = 5f;
        private const float FlockAvoidance = 2f;
        private readonly LayerMask _playerLayer = 1 << 8;
        private readonly LayerMask _enemyLayer = 1 << 9;
        
        private Transform _machineTransform;
        private Transform _playerTransform;
        private NavMeshAgent _agent;
        
        public ChaseState(Transform playerTransform, Transform machineTransform, NavMeshAgent agent) {
            _playerTransform = playerTransform;
            _machineTransform = machineTransform;
            _agent = agent;
            
            _agent.speed = Speed;
        }
        
        public override State PerformState() {
            if (!CanSeePlayer()) return new PatrolState(_playerTransform, _machineTransform, _agent);

            var flockDirection = Flocking();
            OrbitPlayer(flockDirection);

            return this;
        }
        
        //Not square rooting distance for efficiency :P
        private float GetDistanceFromPlayer() => Mathf.Pow(_playerTransform.position.x - _machineTransform.position.x, 2) + Mathf.Pow(_playerTransform.position.z - _machineTransform.position.z, 2);

        private void OrbitPlayer(Vector3 flockDirection) {
            var distanceFromPlayer = GetDistanceFromPlayer();

            var direction = Vector3.zero;
            
            if (distanceFromPlayer < Mathf.Pow(StopDistance - 1f, 2)) 
                direction = _machineTransform.position - _playerTransform.position;
            else if (distanceFromPlayer < Mathf.Pow(StopDistance - 0.5f, 2))
                direction = Vector3.zero;
            else  
                direction = _playerTransform.position - _machineTransform.position;
            
            direction = flockDirection + direction.normalized;
            direction.Normalize();

            _agent.destination = _machineTransform.position + (direction * 8);
            _machineTransform.LookAt(_playerTransform);
        }

        private Vector3 Flocking() {
            var ray = new Ray(_machineTransform.position, Vector3.up);
            var hits = Physics.SphereCastAll(ray, FlockAvoidance, 0.1f);
            
            var directions = Vector3.zero;

            foreach (var hit in hits) {
                if (!hit.transform.CompareTag("Enemy")) continue;
                if (hit.transform.Equals(_machineTransform)) continue;

                var direction = _machineTransform.position - hit.transform.position;
                direction.Normalize();

                directions += direction;
            }

            directions.Normalize();

            return directions;
        }

        private bool CanSeePlayer() {
            var machinePosition = _machineTransform.position;
            var direction = _playerTransform.position - machinePosition;
            direction.Normalize();

            var ray = new Ray(machinePosition, direction);

            return Physics.Raycast(ray, out var hit, ChaseDistance, _playerLayer) && hit.transform.CompareTag("Player");
        }
    }
}