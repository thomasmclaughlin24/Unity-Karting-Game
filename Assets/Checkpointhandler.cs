using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpointhandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        var lapobject = other.gameObject.GetComponent<LapObject>();
        if (lapobject)
        {
            transform.parent.gameObject.GetComponent<KartInfo>().PassCheckpoint(lapobject);
        }
    }
}
