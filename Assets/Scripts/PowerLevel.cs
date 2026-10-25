using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Power Level")]

public class PowerLevel : ScriptableObject
{
    //Applies the power level to the power object
    public int amount;
    public void Apply(Collision collision)
    {
        collision.gameObject.GetComponent<PowerCore>().powerLevel += amount;
    }
}
