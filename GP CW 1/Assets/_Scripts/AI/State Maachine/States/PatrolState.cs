using UnityEngine;
using UnityEngine.AI;

namespace SKhorozian.GPCW.AI
{
    public class PatrolState : State
    {
        private const float NoticeDistance = 15f;

        private Vector3 _destination;
        private Transform _machineTransform;
        private Transform _playerTransform;
        private NavMeshAgent _agent;

        public PatrolState(Transform playerTransform, Transform machineTransform, NavMeshAgent agent) {
            _machineTransform = machineTransform;
            _playerTransform = playerTransform;
            _agent = agent;

            AssignNewDestination();
        }

        public override State PerformState() {
            var machinePosition = _machineTransform.position;

            //if (FindPlayer()) return new AttackState(_playerTransform, _agent);

            var distanceFromDestination = Vector3.Distance(_destination, machinePosition);
            if (distanceFromDestination >= 0.5f) return this;

            AssignNewDestination();

            return this;
        }

        private bool FindPlayer() {
            var machinePosition = _machineTransform.position;
            var direction = machinePosition - _playerTransform.position;
            direction.Normalize();

            var ray = new Ray(machinePosition, direction);

            return Physics.Raycast(ray, out var hit, NoticeDistance) && hit.transform.CompareTag("Player");
        }

        private void AssignNewDestination() {
            var machinePosition = _machineTransform.position;
            
            var x = Random.Range(-5, 5) + machinePosition.x;
            var z = Random.Range(-5, 5) + machinePosition.z;
            _destination = new Vector3(x, machinePosition.y, z);
            
            _agent.SetDestination(_destination);
        }
    }
}
