using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public float rotationSpeed;

    GameManager manager;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        manager.score += 10;
        Destroy(gameObject);
    }
}
