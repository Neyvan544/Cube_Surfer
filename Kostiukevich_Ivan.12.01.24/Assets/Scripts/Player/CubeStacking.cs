using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeStacking : MonoBehaviour
{
    [SerializeField] private StartGame startGame;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private GameObject particleEffectPrefab;
    [SerializeField] private TrailBehindCharacter trail;
    [SerializeField] private CameraShake shaking;
    public List<GameObject> blockList = new List<GameObject>();
    private GameObject lastBlockObject;

    private void Start()
    {
        UpdateLastBlockObject();
    }

    public void IncreaseBlockStack(GameObject _gameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        _gameObject.transform.position = new Vector3(lastBlockObject.transform.position.x,
        lastBlockObject.transform.position.y - 1f, lastBlockObject.transform.position.z);
        _gameObject.transform.SetParent(transform);
        blockList.Add(_gameObject);
        UpdateLastBlockObject();
        GameObject particleEffectInstance = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        Destroy(particleEffectInstance, 3f);
        GameObject floatingTextInstance = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        Destroy(floatingTextInstance, 1f);
    }

    public void DecreaseBlock(GameObject _gameObject)
    {
        if (blockList.Contains(_gameObject))
        {
            PlatformMove platformMoveScript = _gameObject.AddComponent<PlatformMove>();
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            _gameObject.transform.position = new Vector3(lastBlockObject.transform.position.x,
            lastBlockObject.transform.position.y, lastBlockObject.transform.position.z);
            _gameObject.transform.SetParent(null);
            blockList.Remove(_gameObject);
            UpdateLastBlockObject();
        }
        shaking.StartShake();

    }

    private void UpdateLastBlockObject()
    {
        lastBlockObject = blockList[blockList.Count - 1];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && other.GetComponent<BoxCollider>().isTrigger)
        {
            PlatformMove[] platformMoves = FindObjectsOfType<PlatformMove>();
            foreach (PlatformMove platformMove in platformMoves)
            {
                platformMove.StopMove();

            }
            startGame.loseScreen.SetActive(true);
            playerMovement.enabled = false;
            trail.GetComponent<TrailBehindCharacter>().enabled = false;
        }
    }

}

