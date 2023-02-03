using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminadorDeEnemigos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnCollisionEnter2D(Collision2D _col)
    {
        if(_col.gameObject.tag == "Enemigo")
        {
            _col.gameObject.SetActive(false);
            Destroy(_col.gameObject, 0.5f);
        }
    }
}
