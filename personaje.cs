using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{

    public GameObject ataque_original;
    public GameObject ataque_posicion;

    private bool saltando;
    private bool atacando;
    private int vidas;
    private int monedas;
    // Start is called before the first frame update
    void Start() {
        saltando = false;
        atacando = false;
        vidas = 3; 
        monedas = 0;
    }

    // Update is called once per frame
    void Update() {
        //Movimiento del pj
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-0.1f, 0.0f));
        }
        else
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(0.1f, 0.0f));
        }
        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(saltando == false)
            {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 500.0f));
            saltando = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Ataque del pj
            if(atacando == false)
            {
                GameObject.Instantiate(ataque_original, ataque_posicion.transform.position, ataque_posicion.transform.rotation); 
                atacando = true;
                Invoke("TerminaDeAtacar", 0.5f);
            }

        }
    }

    private void TerminaDeAtacar()
    {
        atacando = false;
    }

    void OnCollisionEnter2D(Collision2D _col)
    {
        //Que el pj no pueda spammear el salto
        if(_col.gameObject.tag == "Suelo")
        {
            saltando = false;
        }
        
        if(_col.gameObject.tag == "Enemigo")
        {
            //Quitar vidas al tocar enemigos
            _col.gameObject.SetActive(false);
            Destroy(_col.gameObject, 0.5f);
            //vidas--; es lo mismo que:
            vidas = vidas - 1;
            print("Vidas: " + vidas);
            if(vidas <= 0)
            {
                //Cuando tengas 0 vidas (He muerto)
                print("El jugador ha muerto");
                gameObject.SetActive(false);

                int recordUltimo = PlayerPrefs.GetInt("Monedas");
                if(PlayerPrefs.HasKey("Monedas") == false)
                {
                    //No hay record guardado
                    PlayerPrefs.SetInt("Monedas", monedas);
                    Debug.Log("NUEVO RECORD! " + monedas);
                }
                else
                {
                    //Si hay record guardado
                    if(recordUltimo < monedas)
                    {
                        //Nuevo record
                        PlayerPrefs.SetInt("Monedas", monedas);
                        Debug.Log("NUEVO RECORD! " + monedas);
                        //TODO: poner aqui una pantalla de nuevo record
                    }
                }

            }
        }

    }

    void OnTriggerEnter2D(Collider2D _col)
    {
        //Coger recogibles
        if(_col.gameObject.tag == "Moneda")
        {
            _col.gameObject.SetActive(false);
            Destroy(_col.gameObject, 0.5f);
            //monedas++; es lo mismo que:
            monedas = monedas + 1;
            Debug.Log("Monedas: " + monedas);
        }
    }
}
