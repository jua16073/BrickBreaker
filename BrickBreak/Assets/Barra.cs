using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour {
    Vector3 tras;
    float vel;
    Vector2 pos;
    Bloques cant;
    // Use this for initialization
    void Start () {
        tras = new Vector3(0.0f, 0.0f);
        vel = 12.0f;
        pos = this.gameObject.GetComponent<Rigidbody2D>().position;
        cant = GameObject.Find("Bloques").GetComponent<Bloques>();
	}
	
	// Update is called once per frame
	void Update () {
        if (cant.vidas > 0)
        {
            tras.x = 0;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                tras.x = -vel * Time.deltaTime;
                transform.Translate(tras);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                tras.x = vel * Time.deltaTime;
                transform.Translate(tras);
            }
        } 
    }
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RIGHT")
        {
            transform.position = new Vector2(8f, -4.41f);
        }
        if (collision.gameObject.name == "LEFT")
        {
            transform.position = new Vector2(-8f, -4.41f);
        }
    }
}
