using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialTV : MonoBehaviour
{
    [SerializeField] Renderer tvMaterial;
    float scrollSpeed = 0.5f;
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        tvMaterial.material.mainTextureOffset = new Vector2(offset / Time.deltaTime, -offset);
    }
}
