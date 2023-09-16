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
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
       _v3 = _dir;
        StartCoroutine(DesrtoyBullet());
        _rb.AddForce(_v3 * _speed * Time.deltaTime,ForceMode2D.Impulse);
        //(ForceMode2D)ForceMode.Impulse
    }
    IEnumerator DesrtoyBullet()
    {
        yield return new WaitForSeconds(_lifeTime * Time.deltaTime);        
        print("chau");
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {         
        //_rb.AddForce(_v3* _speed, (ForceMode2D)ForceMode.Impulse);
        //transform.position +=_v3*Time.deltaTime*_speed;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.CompareTag("Asteroid"))
        {
            print("MATO ASTEROIDE");
            Destroy(col.collider.gameObject);
            Destroy(gameObject);
        }
    }
}
