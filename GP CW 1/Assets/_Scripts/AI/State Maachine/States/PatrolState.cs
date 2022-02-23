using UnityEngine;
using UnityEngine.AI;

namespace SKhorozian.GPCW.AI
{
    public class PatrolState : State
    {
        private const float NoticeDistance = 10f;
        private const float Speed = 3f;

        private Vector3 _destination;
        private Transform _machineTransform;
        private Transform _playerTransform;
        private NavMeshAgent _agent;

        private float _timer;

        public PatrolState(Transform playerTransform, Transform machineTransform, NavMeshAgent agent) {
            _machineTransform = machineTransform;
            _playerTransform = playerTransform;
            _agent = agent;

            _agent.speed = Speed;
            
            AssignNewDestination();
        }

        public override State PerformState() {
            if (FindPlayer()) return new AttackState(_playerTransform, _machineTransform, _agent);

            _timer -= Time.deltaTime;
            if (_timer > 0) return this;

            AssignNewDestination();

            return this;
        }

        private bool FindPlayer() {
            var machinePosition = _machineTransform.position;
            var direction = _playerTransform.position - machinePosition;
            direction.Normalize();

            var ray = new Ray(machinePosition, direction);

            return Physics.Raycast(ray, out var hit, NoticeDistance) && hit.transform.CompareTag("Player");
        }

        private void AssignNewDestination() {
            var machinePosition = _machineTransform.position;
            
            var x = Random.Range(-10, 10) + machinePosition.x;
            var z = Random.Range(-10, 10) + machinePosition.z;
            _destination = new Vector3(x, machinePosition.y, z);

            _timer = Random.Range(2, 8);
            
            _agent.SetDestination(_destination);
            
            _machineTransform.LookAt(_destination);
        }
    }
}
