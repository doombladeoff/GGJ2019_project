using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_antivirus : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "antivirus")
        {
            Invoke("desObj", 3);
        }
    }

    void desObj()
    {
        Destroy(gameObject);
    }
}
