using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Tentacle : MonoBehaviour
{
    public int length;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;
    public float trailSpeed;

    private void Start()
    {
        lineRend.useWorldSpace = true;
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    private void Update()
    {
        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);   
        }
        lineRend.SetPositions(segmentPoses);
    }

    private void OnValidate() 
    {

        if(Application.isPlaying)
            return;

        if(!lineRend)
            lineRend = GetComponent<LineRenderer>();

        lineRend.positionCount = length;
        
        for (int i = 0; i < lineRend.positionCount; i++)
        {
            var distance = i * targetDist;
            lineRend.SetPosition(i, transform.right * distance);
        }
        
    }

    
}
