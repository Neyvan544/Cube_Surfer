using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private CubeStacking cubeController;
    private bool isStack = false;

    void Start()
    {
        cubeController = GameObject.FindObjectOfType<CubeStacking>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isStack & other.CompareTag("Player"))
        {
            isStack = true;
            cubeController.IncreaseBlockStack(gameObject);
            gameObject.tag = "Player";
        }
        if (other.CompareTag("Obstacle") & other.GetComponent<BoxCollider>().isTrigger)
        {
            cubeController.DecreaseBlock(gameObject);

        }
    }

}
