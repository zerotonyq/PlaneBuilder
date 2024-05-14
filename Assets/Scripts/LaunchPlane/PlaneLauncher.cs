using System;
using System.Collections;
using System.Collections.Generic;
using CheckContstruction;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlaneLauncher : MonoBehaviour
{
    public ConstructionChecker ConstructionChecker;

    public TextMeshProUGUI launchText;

    public List<ParticleSystem> ParticleSystems = new();
    public List<TrailRenderer> TrailRenderers = new();

    public Transform scaleTransform;
    public Transform planeTransform;
    public Transform planeForward;
    public void Launch()
    {
        var check = ConstructionChecker.Check();
        
        DisplayLaunchButtonText(check);
        
        if (!check)
            return;
        
        EnableParticles();
        EnableTrails();

        var direction =  (planeForward.position - planeTransform.position);
        var initPos = planeTransform.position;
        
        var sequence = DOTween.Sequence();

        planeTransform.parent = null;
        scaleTransform.position = planeTransform.position;
        planeTransform.parent = scaleTransform;
        
        sequence.Append(scaleTransform.DOMove(planeTransform.position + direction * 50f, 10f));
        //sequence.Append(scaleTransform.DOScale(scaleTransform.localScale * 7f, 0.1f));
        //sequence.Append(scaleTransform.DORotateQuaternion( Quaternion.LookRotation(initPos + Vector3.up * 5f + Vector3.back*50f, Vector3.up), 0.1f));
            
        //sequence.Append(scaleTransform.DOLocalRotate(Vector3.up * 180f, 0.1f));
        //sequence.Append(scaleTransform.DOMove(initPos + Vector3.up * 5f + Vector3.forward*100f, 5f));
        
        //launch
    }

    private void EnableTrails()
    {
        foreach (var trailRenderer in TrailRenderers)
        {
            trailRenderer.enabled = true;
        }
    }

    private void EnableParticles()
    {
        foreach (var system in ParticleSystems)
        {
            system.Play();
        }
    }

    public void DisplayLaunchButtonText(bool isCheckSucceeded)
    {
        if (isCheckSucceeded)
        {
            launchText.color = Color.green;
            launchText.text = "Поехали!";
        }
        else
        {
            launchText.color = Color.red;
            launchText.text = "Пуск\n запрещен";
        }
    }
}