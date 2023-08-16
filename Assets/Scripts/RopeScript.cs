using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public Vector2 destiny;

    public float speed = 50f;

    public float distance = .5f;

    public GameObject nodePrefab;

    public GameObject weight;

    public GameObject lastNode;

    bool done = false;

    int vertexCount = 2;

    public LineRenderer lr;

    public List<GameObject> Nodes = new List<GameObject>();

    private void Start()
    {
        lr = GetComponent<LineRenderer>();

        weight = GameObject.FindGameObjectWithTag("Weight");

        lastNode = transform.gameObject;

        Nodes.Add(transform.gameObject);
    }

    [System.Obsolete]
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destiny, speed * Time.deltaTime);

        if((Vector2)transform.position != destiny)
        {
            if (Vector2.Distance(weight.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();
            }
        }
        else if (done == false)
        {
            done = true;

            while(Vector2.Distance(weight.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();
            }

            lastNode.GetComponent<HingeJoint2D>().connectedBody = weight.GetComponent<Rigidbody2D>();
        }

        RenderLine();
    }

    [System.Obsolete]
    private void RenderLine()
    {
        lr.SetVertexCount(vertexCount);

        int i;
        for(i = 0; i < Nodes.Count; i++)
        {
            lr.SetPosition(i, Nodes[i].transform.position);
        }

        lr.SetPosition(i, weight.transform.position);
    }

    private void CreateNode()
    {
        Vector2 pos2Create = weight.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += (Vector2)lastNode.transform.position;

        GameObject go = (GameObject) Instantiate(nodePrefab, pos2Create, Quaternion.identity);

        go.transform.SetParent(transform);

        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();

        lastNode = go;

        Nodes.Add(lastNode);

        vertexCount++;
    }
}
