using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

public class AbilityComponent : MonoBehaviour
{
    [Header("Abilities")]
    [SerializeField] private List<ASAbilityInterface> _defaultAbilities;
    private List<ASAbilityInterface> _currentAbilities;

    private PlayerInputActions playerInputActions;
    
/*
    public List<ASAbilityInterface> CurrentAbilities { get => _currentAbilities; set => _currentAbilities = value; }
*/

    private void Start()
    {

        playerInputActions = GetComponent<PlayerController>().playerInputActions;
        _currentAbilities = new List<ASAbilityInterface>();
        
        foreach (var ability in _defaultAbilities)
        {
            AddAbility(ability);
        }
        
    }

    public bool AddAbility(ASAbilityInterface newAbility)
    {
        if (_currentAbilities.Contains(newAbility)) { return true; }
        
        _currentAbilities.Add(newAbility);

        BindAbility(newAbility.GetBindName(), newAbility);

        return true;
    }

    public bool StartAbility(ASAbilityInterface ability)
    {
        if (!_currentAbilities.Contains(ability)) return false;

        Debug.Log($"Starting {ability.GetName()}");

        if(!ability.CanStart()) return false;
        
        ability.StartAbility(gameObject);
        
        return true;
    }
    
    public bool StopAbility(ASAbilityInterface ability)
    {
        if (!_currentAbilities.Contains(ability)) return false;

        Debug.Log($"Stop {ability.GetName()}");

        if(!ability.CanStop()) return false;
        
        ability.StopAbility(gameObject);
        
        return true;
    }

    void BindAbility(string inputBinding,ASAbilityInterface ability)
    {
        if (!_currentAbilities.Contains(ability)) return;

        Debug.Log($"Binding {ability.GetName()}");

        playerInputActions.FindAction(inputBinding).started += ctx =>
        {
            StartAbility(ability);
        };
        
        playerInputActions.FindAction(inputBinding).performed += ctx =>
        {
            StopAbility(ability);
        };

    }
}
