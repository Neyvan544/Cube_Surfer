using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleVariantCollision : MonoBehaviour
{
    public GameObject[] gfxBlocks;
    private void Start()
    {
        gfxBlocks = GetComponentsInChildrenWithTag("Obstacle");
        EnableBoxColliders(true);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            EnableBoxColliders(false);
        }
    }

    private void EnableBoxColliders(bool enable)
    {
        foreach (GameObject gfxBlock in gfxBlocks)
        {
            BoxCollider boxCollider = gfxBlock.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = enable;
            }

        }
    }
    private GameObject[] GetComponentsInChildrenWithTag(string tag)
    {
        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        GameObject[] resultObjects = new GameObject[childTransforms.Length - 1];

        int resultIndex = 0;
        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform != transform)
            {
                resultObjects[resultIndex] = childTransform.gameObject;
                resultIndex++;
            }
        }

        return resultObjects;
    }
}
