using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _vel = 1;
    [SerializeField] private int _speed = 1;
    private Rigidbody2D _rb;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _head;
    private GameObject _lastBullet;


    // Start is called before the first frame update
    void Start()
    {
       _rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //movement
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            _rb.AddForce(transform.right * _speed*Time.deltaTime);
        }     

        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.eulerAngles += new Vector3(0, 0, -_vel) * Time.deltaTime;
;       }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles += new Vector3(0, 0, _vel) * Time.deltaTime;
        }
        //shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _lastBullet = Instantiate(_bullet, _head.position, Quaternion.identity);
            _lastBullet.GetComponent<BulletController>()._dir = transform.right;
        }

        //limits
        if (transform.position.x < -16.6)
        {
            transform.position = new Vector3(16.7f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 16.7f)
        {
            transform.position = new Vector3(-16.6f, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -16.8f)
        {
            transform.position = new Vector3(transform.position.x, 16.6f, transform.position.z);
        }
        if (transform.position.y > 16.6f)
        {
            transform.position = new Vector3(transform.position.x, -16.8f, transform.position.z);
        }
    }
}
