using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace DefaultNamespace
{
    public class Identifier : MonoBehaviour
    {
        public int Id;
        public List<int> requiredIds = new();
        public List<int> ids = new();
        public List<XRSocketInteractor> sockets = new();

        public List<Identifier> attachetIds = new List<Identifier>();

        public Action OK;
        public void Start()
        {
            foreach (var socket in sockets)
            {
                socket.selectEntered.AddListener(arg0 =>
                {
                    var id = arg0.interactableObject.transform.GetComponent<Identifier>();
                    if (attachetIds.Contains(id))
                        return;
                    attachetIds.Add(id);
                });
                socket.selectExited.AddListener(arg0 =>
                {
                    var id = arg0.interactableObject.transform.GetComponent<Identifier>();
                    if (attachetIds.Contains(id))
                        attachetIds.Remove(id);
                } );
            }
        }

        [ContextMenu("assign ids from identifiers")]
        public void Assign()
        {
            foreach (var id in attachetIds)
            {
                ids.Add(id.Id);
            }
        }
        [ContextMenu("check")]
        public void Check()
        {
            var copy = new List<int>();
            foreach (var requiredId in requiredIds)
            {
                copy.Add(requiredId);
            }
            foreach (var id in ids)
            {
                if (copy.Contains(id))
                    copy.Remove(id);
            }
            if(copy.Count == 0)
                OK?.Invoke();
        }
    }
}