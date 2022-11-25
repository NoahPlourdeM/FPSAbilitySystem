using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName = "Ability")]
public abstract class ASAbilityInterface : ScriptableObject
{
    private string _name;
    private string _bindName;
    private bool _canStart;

    protected ASAbilityInterface(string name,string bindName) { 
        this._name = name;
        this._bindName = bindName;
    }
    public virtual void StartAbility(GameObject instigator) { Debug.Log(GetName()); }
    public virtual bool StopAbility(GameObject instigator){ return true; }
    public virtual bool CanStart(){ return true; }
    public virtual bool CanStop(){ return true; }
    public virtual string GetName(){ return _name; }
    public virtual string GetBindName(){ return _bindName; }
}