using UnityEngine;

/// <summary>
/// This class inherits from TargetObject and represents a LapObject.
/// </summary>
public class LapObject : TargetObject
{
    [Header("LapObject")]
    [Tooltip("Is this the first/last lap object?")]
    public bool finishLap;

    [HideInInspector]
    public bool lapOverNextPass;

    void Start() {
        Register();
    }
    
    void OnEnable()
    {
        lapOverNextPass = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other + " touched checkpoint");
        var kart = other.gameObject.transform.parent.gameObject.GetComponent<KartInfo>();
        if (kart)
        {
            kart.PassCheckpoint(this);
        }
        if (!((layerMask.value & 1 << other.gameObject.layer) > 0 && other.CompareTag("Player")))
            return;
        print(other + " passed the checkpoint");
        Objective.OnUnregisterPickup?.Invoke(this);
    }
}
