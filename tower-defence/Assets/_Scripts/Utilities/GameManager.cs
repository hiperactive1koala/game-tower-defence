using System;
using UnityEngine;

namespace Utilities
{
    
    [Serializable]
    public enum GameState
    {
        MainMenu = 0,
        Loading = 1,
        Playing = 2,
        Dead = 3,
        Win = 4
    }
    public class GameManager : MonoBehaviour
    {
        public static Action<GameState> OnStateChanged;
        public GameState State { get; private set; }

        private void Start() => ChangeState(GameState.MainMenu);

        public void ChangeState(GameState newState)
        {
            if (State == newState) return;
            
            OnStateChanged?.Invoke(newState);
            
            State = newState;
            switch (newState)
            {
                case GameState.MainMenu:
                    HandleMainMenu();
                    break;
                case GameState.Loading:
                    HandleLoading();
                    break;
                case GameState.Playing:
                    HandlePlaying();
                    break;
                case GameState.Dead:
                    HandleDead();
                    break;
                case GameState.Win:
                    HandleWin();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
        }

        private void HandleWin()
        {
            // Finished run 
        }

        private void HandleDead()
        {
            // YOU ARE DEAD
        }

        private void HandlePlaying()
        {
            //  start game / unpause etc...
        }

        private void HandleLoading()
        {
            // call loader and make loading
        }

        private void HandleMainMenu()
        {
            //Set active main menu panel / Pause game / etc...
        }
    }
}