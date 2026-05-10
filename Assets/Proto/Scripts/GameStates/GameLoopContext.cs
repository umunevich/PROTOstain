using Proto.Scripts.Player;
using UnityEngine;

namespace Proto.Scripts.GameStates
{
    public interface IGameLoopContext<in T> where T: BaseGameState
    {
        void TransitionToState(T state);
    }
    
    public class GameLoopContext : MonoBehaviour, IGameLoopContext<BaseGameState>
    {
        public static GameLoopContext Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            TransitionToState(_explorationGameState);
        }

        private void Update()
        {
            _currentState?.UpdateState(this);
        }

        public void TransitionToState(BaseGameState state)
        {
            _currentState?.ExitState(this);
            _currentState = state;
            _currentState.EnterState(this);
        }
        
        private static GameLoopContext _instance;
        
        private readonly ExplorationGameState _explorationGameState = new ExplorationGameState();
        private readonly LevelCompleteGameState _levelCompleteGameState = new LevelCompleteGameState();
        private readonly ShopGameState _shopGameState = new ShopGameState();
        private BaseGameState _currentState;
        
        private PlayerData _playerData;
    }
}
