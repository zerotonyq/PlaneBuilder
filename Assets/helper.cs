using System.Collections;
using System.Collections.Generic;
using FilterSocketInteration.TypeComponent;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[ExecuteInEditMode]
public class helper : MonoBehaviour
{
    [ContextMenu("create")]
    public void Create()
    {
        var childsCount = gameObject.transform.parent.childCount;
        for (int i = 0; i < childsCount; i++)
        {
            
            var child = gameObject.transform.parent.GetChild(i);
            if(child == gameObject.transform)
                continue;
            var obj = new GameObject("socket" + child.name);
            var customSocket = obj.AddComponent<CustomFilterSocketInteractor>(); 
            customSocket.possibleTypes.Add(child.GetComponent<TypeComponent>().Type);
            customSocket.startingSelectedInteractable = child.GetComponent<XRGrabInteractable>();
            customSocket.transform.rotation = child.transform.rotation;
            customSocket.attachTransform = customSocket.transform;
            obj.AddComponent<CapsuleCollider>().isTrigger = true;
            obj.transform.position = child.transform.position;
            obj.transform.parent = gameObject.transform;
        }
    }

    public GameObject canvasPrefab;
    [ContextMenu("create canvases")]
    public void CreateUICanvases()
    {
        var childsCount = gameObject.transform.parent.childCount;
        for (int i = 0; i < childsCount; i++)
        {

            var child = gameObject.transform.parent.GetChild(i);
            var obj = Instantiate(canvasPrefab);
            obj.SetActive(false);
            obj.transform.parent = child;
            obj.transform.localPosition = Vector3.zero;
            

        }
    }

}
