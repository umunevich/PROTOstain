using UnityEngine;

namespace Proto.Scripts.GameStates
{
    public abstract class BaseGameState
    {
        public abstract void EnterState(IGameLoopContext<BaseGameState> context);
        public abstract void UpdateState(IGameLoopContext<BaseGameState> context);
        public abstract void ExitState(IGameLoopContext<BaseGameState> context);
    }
}
