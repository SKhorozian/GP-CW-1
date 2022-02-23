using UnityEngine;
using UnityEngine.AI;

namespace SKhorozian.GPCW.AI
{
    public class AttackState : State
    {
        private Vector3 _destination;
        private Transform _playerTransform;
        private NavMeshAgent _agent;

        public AttackState(Transform playerTransform, NavMeshAgent agent) {
            _playerTransform = playerTransform;
            _agent = agent;
        }
        
        public override State PerformState() {
            throw new System.NotImplementedException();
        }
    }
}