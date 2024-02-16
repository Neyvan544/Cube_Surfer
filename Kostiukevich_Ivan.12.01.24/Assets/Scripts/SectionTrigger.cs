using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject[] roadSection;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Trigger"))
        {
            SpawnGroundSection();
        }
    }
    void SpawnGroundSection()
    {
        int randomIndex = Random.Range(0, roadSection.Length);
        GameObject selectedGroundSection = roadSection[randomIndex];

        Instantiate(selectedGroundSection, new Vector3(0, 2.8f, -54.5f), Quaternion.identity);
    }
}
