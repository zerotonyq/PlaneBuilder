using System;
using System.Collections;
using System.Collections.Generic;
using FilterSocketInteration.Enum;
using FilterSocketInteration.TypeComponent;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomFilterSocketInteractor : XRSocketInteractor
{
    public List<PartType> possibleTypes = new();

    
    protected override void Start()
    {
      base.Start();
      
    }
    
    
    public override bool CanHover(IXRHoverInteractable interactable)
    {
        if (!interactable.transform.TryGetComponent(out TypeComponent component))
            return false;
        
        if (!CheckType(component.Type))
            return false;
        
        return base.CanHover(interactable);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        if (!interactable.transform.TryGetComponent(out TypeComponent component))
            return false;
        
        if (!CheckType(component.Type))
            return false;
        //selectEntered.RemoveAllListeners();
        selectEntered.AddListener((xs) => interactable.transform.GetComponent<Rigidbody>().isKinematic = false);
        selectEntered.AddListener((xs) => interactable.transform.parent = xs.interactorObject.transform.parent.parent);
       
        return base.CanSelect(interactable);
    }
    
    

    private bool CheckType(PartType targetType)
    {
        if (targetType == PartType.None)
            return false;
        
        bool allowed = false;
        
        foreach (var possibleType in possibleTypes)
        {
            if (possibleType == targetType)
                allowed = true;

            if (possibleType == PartType.None)
                return true;
        }

        return allowed;
    }
}
