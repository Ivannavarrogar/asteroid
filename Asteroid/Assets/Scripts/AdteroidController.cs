using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdteroidController : MonoBehaviour
{
    public int _type;
    private Rigidbody2D _rb;
    [SerializeField] private int _range = 9;
    [SerializeField] private int _vel = 9;

    private GameManager _gm;

    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.Instance;
        if (_type==0) 
        {
            Vector2 movement = new Vector2(Random.Range(-_range, _range), (Random.Range(-_range, _range))) * _vel;
            _rb.AddForce(movement);
            _rb.inertia = 0.45f;
        }
        //print(movement);
    }

    // Update is called once per frame
    void Update()
    {
        //limits
        if (transform.position.x < -16.6)
        {
            transform.position = new Vector3(16.7f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 16.7f)
        {
            transform.position = new Vector3(-15.6f, transform.position.y, transform.position.z);
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
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.CompareTag("Player"))
        {
            print("FIN");
            col.collider.gameObject.SetActive(false);
            _gm.End();
        }
    }

    public void Move(Vector2 dir)
    {
        Vector2 movement = dir * _vel;
        _rb.AddForce(movement);
        _rb.inertia = 0.45f;
    }
}
