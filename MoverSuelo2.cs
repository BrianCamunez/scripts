using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSuelo2 : MonoBehaviour
{
    public float scrollSpeed;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
      rend = GetComponent<Renderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        //Cambiar el Offset de del material
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));
    }
}
