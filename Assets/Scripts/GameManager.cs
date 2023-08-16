using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform spawnPoint;

    public GameObject weight;

    GameObject curWeight;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        curWeight = Instantiate(weight, spawnPoint.position, Quaternion.identity);
    }

    private void Update()
    {
        if (curWeight == null)
        {
            curWeight = Instantiate(weight, spawnPoint.position, Quaternion.identity);
        }
    }
}
