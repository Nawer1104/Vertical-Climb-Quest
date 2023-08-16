using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHook : MonoBehaviour
{
    public GameObject hook;

    GameObject curHok;

    bool ropeActive;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (ropeActive == false)
            {
                Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                curHok = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);

                curHok.GetComponent<RopeScript>().destiny = destiny;

                ropeActive = true;
            }
            else
            {
                DestroyCurHook();

                ropeActive = false;
            }

        }
    }

    public void DestroyCurHook()
    {
        Destroy(curHok);
    }
}
