using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName = "Ability/Run")]
public class AbilityRun : ASAbilityInterface
{
    [SerializeField]private string name = "Run";
    [SerializeField]private string bindName;
    [SerializeField]private float speedOffset;
    [SerializeField]private bool canStart = true;
    
    public AbilityRun(string name,string bindName) : base(name,bindName)
    {
        this.name = name;
        this.bindName = bindName;
    }
    
    public override void StartAbility(GameObject instigator)
    {
        Debug.Log("Started Running");
        instigator.GetComponent<PlayerController>().Speed += speedOffset;
    }

    public override bool StopAbility(GameObject instigator)
    {
        Debug.Log("Stopped Running");
        instigator.GetComponent<PlayerController>().Speed -= speedOffset;

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
