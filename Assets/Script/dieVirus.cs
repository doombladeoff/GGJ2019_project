using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieVirus : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "virus")
            Destroy(collision.gameObject);
    }
}
