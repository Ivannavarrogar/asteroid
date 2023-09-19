using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverWindow;

    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private GameObject _startWindow;
    [SerializeField] private TMPro.TMP_Text _score;
    private GameManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        //Code for oppening the pause menu with Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             if (!_pauseWindow.activeSelf && !_startWindow.activeSelf)Pause();
             else if (!_startWindow.activeSelf) Resume();
        }
    }
    /// <summary>
    /// Opens the game over menu
    /// </summary>
    public void GameOver()
    {
        _gameOverWindow.SetActive(true);
    }
    /// <summary>
    /// On button click. Resets the game
    /// </summary>
    public void ResetGame()
    {
        _gm.Resume();
        SceneManager.LoadScene(0);
        
    }
    /// <summary>
    /// On button click.Resumes the game
    /// </summary>
    public void Resume()
    {
        _pauseWindow.SetActive(false);
        _gm.Resume();
    }
    /// <summary>
    /// On button click. Pauses the game
    /// </summary>
    public void Pause()
    {
        _pauseWindow.SetActive(true);
        _gm.Pause();
    }
    /// <summary>
    /// On button click. Starts the game
    /// </summary>
    public void StartGame()
    {
        _startWindow.SetActive(false);
        _gm.Resume();
    }
    /// <summary>
    /// Refresh the escore adding value
    /// </summary>
    /// <param name="value"></param>
    public void RefreshScore(string value)
    {
        _score.text ="Score: "+ value;
    }
}
