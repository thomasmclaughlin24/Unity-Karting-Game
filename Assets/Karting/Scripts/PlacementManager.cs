using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlacementManager : MonoBehaviour
{
    public List<KartInfo> Karts;
    public List<String> Placements;
    private UnityEngine.AI.NavMeshAgent Agent;
    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Placements = new List<String>();
        foreach (KartInfo Kart in Karts)
        {
            Placements.Add(Kart.Name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var Scores = new Dictionary<KartInfo, float>();
        foreach (KartInfo Kart in Karts)
        {
            Scores.Add(Kart, GetScore(Kart));
        }
        var MyList = Scores.ToList();
        MyList.Sort((Pair1, Pair2) => Pair1.Value.CompareTo(Pair2.Value));
        Placements.Clear();
        foreach (var Pair in MyList)
        {
            //print(Pair);
            Placements.Add(Pair.Key.Name);
        }
        Placements.Reverse();
    }

    float GetScore(KartInfo Kart)
    {
        if (Kart.Checkpoints.Count == 0)
        {
            return 0;
        }
        LapObject PreviousCheckpoint = Kart.Checkpoints[Kart.Checkpoints.Count - 1];
        float DistancefromPreviousCheckpoint = 0;
        UnityEngine.AI.NavMeshPath Path = new UnityEngine.AI.NavMeshPath();
        bool PathExists = UnityEngine.AI.NavMesh.CalculatePath(Kart.gameObject.transform.position, PreviousCheckpoint.gameObject.transform.position, UnityEngine.AI.NavMesh.AllAreas, Path);
        if (PathExists && Path.status != UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
            transform.position = Kart.gameObject.transform.position;
            Agent.SetDestination(PreviousCheckpoint.gameObject.transform.position);
            DistancefromPreviousCheckpoint = GetPathDistance(Agent) / 1000;
            if (float.IsInfinity(DistancefromPreviousCheckpoint))
            {
                //DistancefromPreviousCheckpoint = 0;
            }
        }
        return Kart.Checkpoints.Count + DistancefromPreviousCheckpoint;
    }

    private float GetPathDistance(UnityEngine.AI.NavMeshAgent Agent)
    {   
        //if (!Agent.pathPending || Agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid || Agent.path.corners.Length == 0)
        //{
            //return 0;
        //}
        if (Agent.path.corners.Length < 2)
        {
            return Agent.remainingDistance;
        }
        float PathDistance = 0;
        for (int I = 0; I < Agent.path.corners.Length - 1; ++I)
        {
            PathDistance += Vector3.Distance(Agent.path.corners[I], Agent.path.corners[I + 1]);
        }
        return PathDistance;
    }

    /*public void PassedCheckpoint(GameObject Kart, GameObject Checkpoint)
    {
        try
        {
            var CheckpointList = new List<GameObject>();
            CheckpointList.Add(Checkpoint);
            KartCheckpoints.Add(Kart, CheckpointList);
        }
        catch (KeyNotFoundException)
        {
            KartCheckpoints[Kart].Add(Checkpoint);
        }
    }*/
}
