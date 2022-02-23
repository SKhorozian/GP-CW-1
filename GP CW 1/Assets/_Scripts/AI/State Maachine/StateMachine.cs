using UnityEngine;

namespace SKhorozian.GPCW.AI
{
    public abstract class StateMachine : MonoBehaviour
    {
        private State _currentState;

        private void Update() {
            var nextState = _currentState.PerformState();
            _currentState = nextState;
        }
    }
}