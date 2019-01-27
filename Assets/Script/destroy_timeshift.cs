using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_timeshift : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            Invoke("desObj", 2);
        }
    }

    void desObj()
    {
        Destroy(gameObject);
    }
}
