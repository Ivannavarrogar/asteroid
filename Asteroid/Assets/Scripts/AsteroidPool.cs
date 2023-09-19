using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    [SerializeField] private GameObject _asteroidPrefab;
    [SerializeField] private GameObject _asteroid2Prefab;
    [SerializeField] private int poolSize = 30;
    [SerializeField] private int poolSize2 = 30;
    [SerializeField] private List<GameObject> _asteroidList;
    [SerializeField] private List<GameObject> _asteroid2List;
    private static AsteroidPool instance;
    public static AsteroidPool Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject asteroid = Instantiate(_asteroidPrefab);
            asteroid.SetActive(false);
            _asteroidList.Add(asteroid);
            asteroid.GetComponent<AdteroidController>()._type = 0;
            asteroid.transform.parent = transform;
        }
        for (int i = 0; i < poolSize2; i++)
        {
            GameObject asteroid = Instantiate(_asteroid2Prefab);
            asteroid.SetActive(false);
            _asteroid2List.Add(asteroid);
            asteroid.GetComponent<AdteroidController>()._type = 1;
            asteroid.transform.parent = transform;
        }
    }
    /// <summary>
    /// Returns an avalible asteroid in the pool, if int is 0, returns big asteroid, if int is 1, returns little asteroid
    /// </summary>
    /// <returns></returns>
    public GameObject Requestasteroid(int val)
    {
        if (val == 0)
        {
            for (int i = 0; i < _asteroidList.Count; i++)
            {
                if (!_asteroidList[i].activeSelf)
                {
                    _asteroidList[i].SetActive(true);
                    return _asteroidList[i];
                }
            }
        }
        if (val==1)
        {
            for (int i = 0; i < _asteroid2List.Count; i++)
            {
                if (!_asteroid2List[i].activeSelf)
                {
                    _asteroid2List[i].SetActive(true);
                    return _asteroid2List[i];
                }
            }
        }
        return null;
    }
}
