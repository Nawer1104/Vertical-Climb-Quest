using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    public GameObject vfx;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            GameObject explosion = Instantiate(vfx, transform.position, Quaternion.identity);
            Destroy(explosion, 0.75f);
            ThrowHook throwHook = GetComponent<ThrowHook>();
            throwHook.DestroyCurHook();
            Destroy(gameObject);
        }
    }
}
