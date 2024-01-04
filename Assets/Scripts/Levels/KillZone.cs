using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    // Al momento que un objeto entra al collider, existene mas tipos de triggers
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            PlayerConroller conroller = collision.GetComponent<PlayerConroller>();
            conroller.Die();
        }
    }
}
