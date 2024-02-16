using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
   public static bool startGame = false;

    void Update()
    {
        if (startGame)
        {
            transform.position += new Vector3(0, 0, 6) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
    public void StartMoving()
    {
        startGame = true;
    }
    public void StopMove()
    {
        startGame = false;
    }
}
