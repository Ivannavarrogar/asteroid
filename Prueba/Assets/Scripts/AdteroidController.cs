using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdteroidController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private int _vel = 9;

    // Start is called before the first frame update
    void Start()
    {
        _rb =GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector2(Random.Range(-_vel, _vel) , (Random.Range(-_vel, _vel))) * Time.deltaTime);
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
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.CompareTag("Player"))
        {
            print("FIN");
            col.collider.gameObject.SetActive(false);
            
        }
    }
}
