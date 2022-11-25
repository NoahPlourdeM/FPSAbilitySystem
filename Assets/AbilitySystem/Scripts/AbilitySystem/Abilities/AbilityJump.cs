using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName = "Ability/BasicJump")]
public class AbilityJump : ASAbilityInterface
{
    [SerializeField]private string name;
    [SerializeField]private string bindName;
    [SerializeField]private float jumpHeight;
    [SerializeField]private bool canStart = true;
    
    public AbilityJump(string name,string bindName) : base(name,bindName)
    {
        this.name = name;
        this.bindName = bindName;
    }
    
    public override void StartAbility(GameObject instigator)
    {
        Debug.Log("Jumping");
        instigator.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
    }

    public override bool StopAbility(GameObject instigator)
    {
        Debug.Log("Stop Jumping");
        return true;
    }

    public override bool CanStart()
    {
        return true;
    }

    public override bool CanStop()
    {
        return true;
    }

    public override string GetName()
    {
        return name;
    }
    public override string GetBindName()
    {
        return bindName;
    }
}
