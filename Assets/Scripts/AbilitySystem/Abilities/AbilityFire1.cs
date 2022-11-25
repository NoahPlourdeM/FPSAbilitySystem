using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName = "Ability/Fire1")]
public class AbilityFire1 : ASAbilityInterface
{
    [SerializeField]private string name;
    [SerializeField]private string bindName;
    [SerializeField]private string message;
    [SerializeField]private bool canStart = true;
    
    public AbilityFire1(string name, string bindName) : base(name, bindName)
    {
    }

    public override void StartAbility(GameObject instigator)
    {
        Debug.Log($"{message}");
    }

    public override bool StopAbility(GameObject instigator)
    {
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
