using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centralizeInventory : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    void Update()
    {
        transform.position += (transform.parent.position - transform.position) * speed * Time.deltaTime;
    }
}
