using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _uiController;
    [SerializeField] private GameObject _uiPause;
    [SerializeField] private Button _buttonExit;
    [SerializeField] private Button _buttonResume;

    private StateGame _stateGame;
    
    private void Awake()
    {
        ResumeGame();
        _stateGame = StateGame.Game;
        _buttonExit.onClick.AddListener(ExitGame);
        _buttonResume.onClick.AddListener(ResumeGame);
    }

    private void Update()
    {
#if UNITY_ANDROID
        if (Input.GetKey(KeyCode.Escape))
        {
            _stateGame = StateGame.Pause;
        }
#endif
        ControllState();
    }

    private void ControllState()
    {
        switch (_stateGame)
        {
            case StateGame.Pause:
                PauseGame();
                break;
        }
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void ResumeGame()
    {
        _uiController.SetActive(true);
        _uiPause.SetActive(false);
        Time.timeScale = 1;
        _stateGame = StateGame.Game;
    }

    private void PauseGame()
    {
        _uiController.SetActive(false);
        _uiPause.SetActive(true);
        Time.timeScale = 0;
    }
}

public enum StateGame
{
    Pause,
    Game
}
