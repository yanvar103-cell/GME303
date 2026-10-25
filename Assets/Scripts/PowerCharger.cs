using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCharger : PowerBase //Inherit from PowerBase
{
    public PowerLevel powerLevel;
    
    //Detect collision from PowerCore
    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision); //Use base. to run the parent’s version and then add your own:
        if(collision.gameObject.CompareTag("PowerCore"))
        {
            PowerCore powerCore = collision.gameObject.GetComponent<PowerCore>();
            //Apply the power level to Power Core
            powerLevel.Apply(collision);
            //Apply color
            powerCore.ChangeColor();
        }
    }
}
