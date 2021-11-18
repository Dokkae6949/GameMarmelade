using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Parralax : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float parralax = 2f;

    void Update()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material materal = meshRenderer.material;
        Vector2 offset = materal.mainTextureOffset;

        offset.x = playerTransform.position.x / playerTransform.localScale.x / parralax;
        offset.y = playerTransform.position.y / playerTransform.localScale.y / parralax;

        materal.mainTextureOffset = offset;
    }
}
