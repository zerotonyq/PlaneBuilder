using System;
using System.Collections.Generic;
using FilterSocketInteration.TypeComponent;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

namespace CheckContstruction
{
    public class ConstructionChecker : MonoBehaviour
    {
        public List<CustomFilterSocketInteractor> sockets = new();
        public TextMeshProUGUI checkText;

        public Action<bool> OnChecked;

        public void Start()
        {
            OnChecked += ChangeCheckedButtonColor;
        }

        public void CheckConstruction()
        {
            OnChecked?.Invoke(Check());
        }
        
        public bool Check()
        {
            foreach (var socket in sockets)
            {
                if (socket.firstInteractableSelected == null)
                {
                    Debug.Log("check failed!");
                    return false;
                }
            }

            Debug.Log("checked!");
            return true;
        }
        
        public void ChangeCheckedButtonColor(bool isCheckSucceeded)
        {
            if (isCheckSucceeded)
            {
                checkText.color = Color.green;
                checkText.text = "Успешно";
            }
            else
            {
                checkText.color = Color.red;
                checkText.text = "Неправильная сборка";
            }
        }
    }
}