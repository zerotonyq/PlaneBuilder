using System;
using FilterSocketInteration.Enum;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace FilterSocketInteration.TypeComponent
{
    public class TypeComponent : MonoBehaviour
    {
        public PartType Type;

        public void Start()
        {
            var interactable = GetComponent<XRGrabInteractable>();
            interactable.selectEntered.AddListener( a =>
            {
                Debug.Log(a.interactorObject.transform.name);
                if(a.interactorObject.transform.CompareTag("Player"))
                    transform.GetChild(0).gameObject.SetActive(true);
            });
            interactable.selectExited.AddListener( a => transform.GetChild(0).gameObject.SetActive(false));
        }
    }
}