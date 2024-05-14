using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class checker : MonoBehaviour
{

    public List<Identifier> CheckIdentifiers = new();
    public int countOK;
    public int currentCountOK = 0;

    public UnityEvent EventOK;
    public UnityEvent EventFailed;
    public void Start()
    {
        countOK = CheckIdentifiers.Count;
        foreach (var identifier in CheckIdentifiers)
        {
            identifier.OK += () => currentCountOK += 1;
        }
    }

    [ContextMenu("checkAll")]
    public void Check()
    {
        foreach (var identifier in CheckIdentifiers)
        {
            identifier.Assign();
            identifier.Check();
        }
        
        if(countOK == currentCountOK)
            EventOK?.Invoke();
        else
            EventFailed?.Invoke();
    }
}
