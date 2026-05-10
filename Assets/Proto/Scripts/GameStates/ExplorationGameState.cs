using Proto.Scripts.Level;
using UnityEngine;

namespace Proto.Scripts.GameStates
{
    public class ExplorationGameState : BaseGameState
    {
        public override void EnterState(IGameLoopContext<BaseGameState> context)
        {
            var generator = Object.FindFirstObjectByType<LevelGenerator>();
            if (generator != null)
            {
                generator.Generate();
            }
        }

        public override void UpdateState(IGameLoopContext<BaseGameState> context)
        {
            
        }

        public override void ExitState(IGameLoopContext<BaseGameState> context)
        {
            
        }
    }
}
