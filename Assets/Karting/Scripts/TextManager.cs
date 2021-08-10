using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public PlacementManager PM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var place = PM.Placements.FindIndex(0, PM.Placements.Count, x => x.Equals("Thomas")) + 1;
        var modifier = "th";
        if (place == 1)
        {
            modifier = "st";
        }
        if (place == 2)
        {
            modifier = "nd";
        }
        if (place == 3)
        {
            modifier = "rd";
        }
        GetComponent<TextMeshProUGUI>().text = place.ToString() + modifier;
    }
}
