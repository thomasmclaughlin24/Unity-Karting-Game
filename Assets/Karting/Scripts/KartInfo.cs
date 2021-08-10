using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartInfo : MonoBehaviour
{
    public string Name = "Bob";
    public List<LapObject> Checkpoints;
    public int numCheckpoints;
    // Start is called before the first frame update
    void Start()
    {
        Checkpoints = new List<LapObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PassCheckpoint(LapObject Checkpoint)
    {
        Checkpoints.Add(Checkpoint);
        //print("Added Checkpoint for " + Name);
    }
}
