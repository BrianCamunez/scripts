using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject objeto_original;
    public float probabilidadDeAparicion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      DecideSiAparece();
    }

    private void DecideSiAparece()
    {
        //Aparicion de recogibles aleatorio
        float random = Random.Range(0.0f, 100.0f);
        if(random < probabilidadDeAparicion)
        {
            GameObject.Instantiate(objeto_original, transform.position, transform.rotation);
        }
    }
}
