using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdteroidController : MonoBehaviour
{
    public int _type;
    private Rigidbody2D _rb;
    [SerializeField] private int _range = 9;
    [SerializeField] private int _vel = 9;
    [SerializeField] private int _turnSpeed = 500;

    private Vector2 _movement;
    private Quaternion _rotation;
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
            _movement = new Vector2(Random.Range(-_range, _range), (Random.Range(-_range, _range))) * _vel;
            _rb.AddForce(_movement);
            _rb.inertia = 0.45f;
        }      
    }

    // Update is called once per frame
    void Update()
    {
        //Orientation
        _rotation = Quaternion.LookRotation(Vector3.forward, -_rb.velocity) ;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, _turnSpeed * Time.deltaTime);            

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
    /// <summary>
    /// Ends the game if the player hits an asteroid
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.CompareTag("Player"))
        {
            print("FIN");
            col.collider.gameObject.SetActive(false);
            _gm.End();
        }
    }

    /// <summary>
    /// Auxiliar function for adding force to the new mini asteroids
    /// </summary>
    /// <param name="dir"></param>
    public void Move(Vector2 dir)
    {
        Vector2 movement = dir * _vel*2;
        _rb.AddForce(movement);
        _rb.inertia = 0.45f;
    }
    /// <summary>
    /// Auxiliar function for adding force to the new big asteroids
    /// </summary>
    public void MoveBig()
    {
        Vector2 movement = new Vector2(Random.Range(-_range, _range), (Random.Range(-_range, _range))) * _vel;
        _rb.AddForce(movement);
        _rb.inertia = 0.45f;
    }
}
