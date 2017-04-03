using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola1 : MonoBehaviour {
    Bloques cant;
    Vector2 pos;
    Vector2 newpos;
    public GameObject prefab;
    Rigidbody2D vel;
	// Use this for initialization
	void Start () {
        cant = GameObject.Find("Bloques").GetComponent<Bloques>();
        this.gameObject.name = "Bola";
        vel = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        newpos = GameObject.Find("Barra").GetComponent<Rigidbody2D>().position;
        if (cant.vidas > 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                pos.y = 9.0f;
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    pos.x = 11.0f;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    pos.x = -11.0f;
                }
                vel.velocity = pos;
            }
            if (vel.velocity.x == 0 && vel.velocity.y == 0)
            {
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
                {
                    pos = newpos;
                    pos.y = newpos.y + 0.5f;
                    transform.position = pos;
                }
            }  
        }

	}

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("nani");
        if (collision.gameObject.name== "UP")
        {
            Debug.Log("nani");
            pos.y = -pos.y;
            vel.velocity = pos;
        }
        if (collision.gameObject.name == "RIGHT")
        {
            pos.x = -pos.x;
            vel.velocity = pos;
        }
        if (collision.gameObject.name == "LEFT")
        {
            pos.x = -pos.x;
            vel.velocity = pos;
        }
        if (collision.gameObject.name == "DOWN")
        {
            Destroy(this.gameObject);
            pos = newpos;
            pos.y = newpos.y + 0.5f;
            Instantiate(prefab, pos, Quaternion.identity);
            cant.vidas--;
        }
        if (collision.gameObject.name== "Barra")
        {
            pos.y = -pos.y;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                pos.x = 11.0f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                pos.x = -11.0f;
            }
            vel.velocity = pos;
        }
        if (collision.gameObject.name== "Bloques(Clone)")
        {

        }
    }


    private void Awake()
    {
        GetComponent<Bola1>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
