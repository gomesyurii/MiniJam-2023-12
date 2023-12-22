using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDimension : MonoBehaviour
{

    public bool GravityCanChange = false;


    void Update()
    {

       if (!GravityCanChange)
        {
            Debug.Log("Being called gravity");
            Physics2D.gravity = new Vector2(0, -9.81f);

        }
        else
        {
            Physics2D.gravity = new Vector2(0, 9.81f);
        }
       

    }
    void OnMouseDown()
    {
        // Função chamada quando o objeto é clicado
        Debug.Log("Objeto clicado!");
        GravityCanChange = !GravityCanChange;
    }
}