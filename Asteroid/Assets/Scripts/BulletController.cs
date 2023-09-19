using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector2 _dir;
    private Vector3 _v3;
    [SerializeField] private int _lifeTime = 3;
    [SerializeField] private float _speed=2;
    Rigidbody2D _rb;
    private int _offset = 1;
    // Start is called before the first frame update
    void Start()
    {

    }
    /// <summary>
    /// Called every time the player shots
    /// </summary>
    public void ChangeForce()
    {
        _rb = GetComponent<Rigidbody2D>();
        _v3 = _dir;
        _rb.AddForce(_v3 * _speed, ForceMode2D.Impulse);
        StartCoroutine(DesrtoyBullet());
    }
    // Update is called once per frame
    void Update()
    {         

    }
    /// <summary>
    /// Hides the bullet after the lifetime
    /// </summary>
    /// <returns></returns>
    IEnumerator DesrtoyBullet()
    {
        yield return new WaitForSeconds(_lifeTime * Time.deltaTime);
        print("chau");
        gameObject.SetActive(false);
        gameObject.transform.position = Vector2.zero;
    }
    /// <summary>
    /// Destrois the asteroid if the bullet hits, hides the bullet and adds points to the global score
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.CompareTag("Asteroid"))
        {
            if (col.collider.gameObject.GetComponent<AdteroidController>()._type==1)
            {
                print("MATO ASTEROIDE");
                GameManager.Instance.AddScore(5);
                col.collider.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
            if(col.collider.gameObject.GetComponent<AdteroidController>()._type == 0)
            {
                print("DIVIDO ASTEROIDE");
                GameManager.Instance.AddScore(10);
                col.collider.gameObject.SetActive(false);
                gameObject.SetActive(false);
              ///New asteroids with angle from the bullet direction
                var newAsteroid1 = AsteroidPool.Instance.Requestasteroid(1);
                var newAsteroid2 = AsteroidPool.Instance.Requestasteroid(1);
                newAsteroid1.transform.position = col.collider.gameObject.transform.position;
                newAsteroid2.transform.position = col.collider.gameObject.transform.position;
                newAsteroid1.GetComponent<AdteroidController>().Move(new Vector2(_dir.x + _offset, _dir.y- _offset));
                newAsteroid2.GetComponent<AdteroidController>().Move(new Vector2(_dir.x - _offset, _dir.y + _offset));

            }

        }
    }
}
