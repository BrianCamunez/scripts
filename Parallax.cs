using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public GameObject[] fondos;
    public float[] velocidadFondos;
    public float[] tamaños;


    public Renderer[] olas;
    public float[] velocidadOla;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        MueveOlas();
        MueveFondos();
    }

    private void MueveFondos()
    {
        for (int i = 0; i < fondos.Length; i++)
        {
            if(Mathf.Abs(fondos[i].transform.localPosition.x) >= tamaños[i])
            {
                // Regresa el fondo a su posición original
                fondos[i].transform.localPosition = new Vector3(0.0f, fondos[i].transform.localPosition.y, fondos[i].transform.localPosition.z);
            }
            else
            {
                //Moviendo el fondo
                float offset = Time.deltaTime * velocidadFondos[i];
                fondos[i].transform.localPosition += new Vector3(offset, 0.0f);
            }
        }
    }

    private void MueveOlas()
    {
        for (int i = 0; i < olas.Length; i++)
        {
            //Cambiar el Offset de del material
            float offset = Time.time * velocidadOla[i];
            olas[i].material.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));
        }
        
    }
}
