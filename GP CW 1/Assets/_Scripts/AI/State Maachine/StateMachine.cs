using System;
using UnityEngine;
using UnityEngine.AI;

namespace SKhorozian.GPCW.AI
{
    public class StateMachine : MonoBehaviour
    {
        private State _currentState;
        [SerializeField] private NavMeshAgent agent;
        
        private void Start() {
            if (!agent) agent = GetComponent<NavMeshAgent>();
            
            agent.updateRotation = false;
            _currentState = new PatrolState(GameObject.FindWithTag("Player").transform, transform, agent);
        }

        private void Update() {
            _currentState = _currentState.PerformState();
        }
    }
}