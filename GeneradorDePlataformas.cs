using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDePlataformas : MonoBehaviour
{
    public GameObject plataforma_original;
    public float probabilidadDeAparicion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      DecideSiPlataformas();
    }

    private void DecideSiPlataformas()
    {
        //Aparicion de recogibles aleatorio
        float random = Random.Range(0.0f, 100.0f);
        if(random < probabilidadDeAparicion)
        {
            GameObject.Instantiate(plataforma_original, transform.position, transform.rotation);
        }
    }
}
