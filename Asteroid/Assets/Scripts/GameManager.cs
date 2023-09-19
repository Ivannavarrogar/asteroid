using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _ui;
    private int _score = 0;

    [SerializeField] private GameObject[] _spawners = new GameObject[4];

    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }
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

        //Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=0;
        for (int i= 0; i<4;i++)
        {
            var asteroid = AsteroidPool.Instance.Requestasteroid(0);
            asteroid.transform.position = _spawners[Random.Range(0,4)].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void End()
    {
        _ui.GameOver();
    }
    /// <summary>
    /// Adds the value to global score and calls ui manager to show in screen
    /// </summary>
    /// <param name="value"></param>
    public void AddScore(int value)
    {
        _score += value;
        _ui.RefreshScore(_score.ToString());
    }


    ///TODO 
    ///HACER QUE SEA INFINITO, CUANDO HAYA MENOS DE X ASTEROIDES GRANDES SPAWNEAR MAS
}
