using UnityEngine;

public class CanvasRotator : MonoBehaviour
{
    public Camera cam;
    public Canvas canvas;

    private void Start()
    {
        cam = Camera.main;
        canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        canvas.transform.LookAt(cam.transform);
        canvas.transform.position = transform.parent.position + Vector3.up / 5;
    }
}