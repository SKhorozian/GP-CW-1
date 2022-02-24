using System;
using UnityEngine;
using UnityEngine.AI;

namespace SKhorozian.GPCW.AI
{
    public class StateMachine : MonoBehaviour
    {
        private State _currentState;

        [field: SerializeField] public NavMeshAgent Agent { get; private set; }
        [field: SerializeField] public ParticleSystem ParticleSystem { get; private set; }
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
        
        private void Start() {
            if (!Agent) Agent = GetComponent<NavMeshAgent>();
            
            ParticleSystem.Stop(true);

            Agent.updateRotation = false;
            _currentState = new PatrolState(GameObject.FindWithTag("Player").transform, this);
        }

        private void Update() {
            _currentState = _currentState.PerformState();
        }
    }
}