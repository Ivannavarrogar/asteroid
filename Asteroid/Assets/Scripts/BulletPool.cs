using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int poolSize = 30;
    [SerializeField] private List<GameObject> _bulletList;
    private static BulletPool instance;
    public static BulletPool Instance { get { return instance; } }

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
        ////Instantiate the objects in the pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.SetActive(false);
            _bulletList.Add(bullet);
            bullet.transform.parent = transform;    
        }
    }
    /// <summary>
    /// Returns an avalible bullet in the pool
    /// </summary>
    /// <returns></returns>
    public GameObject RequestBullet()
    {
        for (int i = 0;i < _bulletList.Count;i++)
        {
            if (!_bulletList[i].activeSelf)
            {
                _bulletList[i].SetActive(true);
                return _bulletList[i];
            }
        }  
        return null;
    }

}
