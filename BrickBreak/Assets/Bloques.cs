using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class Bloques : MonoBehaviour {
    public int cantidad;
    public GameObject bloque;
    Vector2 pos = new Vector2(-8, 0.67f);
    public int score;
    public Text scores;
    public int vidas;
    public Text vida;
    public Text mensaje;
	// Use this for initialization
	void Start () {
        cantidad = 0;
        vidas = 3;
        mensaje.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        pos.x = -8;
        pos.y = 0.67f;
        if (cantidad == 0)
        {
                while (pos.y < 3)
                {
                    while (pos.x < 9)
                    {
                        Instantiate(bloque, pos, Quaternion.identity);
                        pos.x = pos.x + 2;
                        cantidad++;
                    }
                    pos.y = pos.y + 1;
                    pos.x = -8;
                }
        }
        scores.text = score.ToString();
        vida.text = vidas.ToString();
        if (vidas == 0)
        {
            mensaje.enabled = true;
        }
        if (Input.GetKey(KeyCode.N)){
            vidas = 3;
            score = 0;
            mensaje.enabled = false;
        }
    }
}
