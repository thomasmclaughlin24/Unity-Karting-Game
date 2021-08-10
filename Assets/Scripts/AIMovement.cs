using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform[] points;
    private int nextpoint = 0;
    private UnityEngine.AI.NavMeshAgent Agent;
    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Agent.autoBraking = false;
        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
            return;
        Agent.destination = points[nextpoint].position;
        nextpoint = (nextpoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Agent.pathPending && Agent.remainingDistance < 5)
            GoToNextPoint();
    }
}
