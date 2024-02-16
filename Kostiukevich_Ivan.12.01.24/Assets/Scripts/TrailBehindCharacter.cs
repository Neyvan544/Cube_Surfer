using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailBehindCharacter : MonoBehaviour
{
    public float lifetime = 5f;
    public float minimumVertexDistance = 0.1f;
    public float trailHeight = 0.1f;
    public LayerMask collisionLayer;
    public Vector3 velocity;

    LineRenderer line;
    List<Vector3> points;
    Queue<float> spawnTimes;

    void Awake()
    {
        gameObject.SetActive(false);
        line = GetComponent<LineRenderer>();
        line.useWorldSpace = true;
        points = new List<Vector3>() { transform.position };
        spawnTimes = new Queue<float>();
        line.SetPositions(points.ToArray());
        
    }

    void AddPoint(Vector3 position)
    {
        points.Insert(1, position);
        spawnTimes.Enqueue(Time.time);
    }

    void RemovePoint()
    {
        spawnTimes.Dequeue();
        points.RemoveAt(points.Count - 1);
    }

    void Update()
    {

        while (spawnTimes.Count > 0 && spawnTimes.Peek() + lifetime < Time.time)
        {
            RemovePoint();
        }

        Vector3 diff = -velocity * Time.deltaTime;
        for (int i = 1; i < points.Count; i++)
        {
            points[i] += diff;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, collisionLayer))
        {

            Vector3 hitPoint = new Vector3(hit.point.x, trailHeight, hit.point.z);
            AddPoint(hitPoint);
        }
        points[0] = transform.position;
        line.positionCount = points.Count;
        line.SetPositions(points.ToArray());
    }
}
