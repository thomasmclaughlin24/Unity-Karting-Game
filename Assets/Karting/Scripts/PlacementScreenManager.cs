using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlacementScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlacementManager placementManager;
    public TextMeshProUGUI FirstPlace;
    public TextMeshProUGUI SecondPlace;
    public TextMeshProUGUI ThirdPlace;
    public void UpdatePlacements()
    {
        FirstPlace.text = placementManager.Placements[0];
        SecondPlace.text = placementManager.Placements[1];
        ThirdPlace.text = placementManager.Placements[2];
    }
}
