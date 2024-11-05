using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapliSSSgng : MonoBehaviour
{
    private Camera _camera;
    private DistanceJoint2D _distanceJoint;
    private LineRenderer _lineRenderer;
    private Vector2 grapplePoint;
    private Vector2 tempPoint;
    bool isGrapp;

    [SerializeField]
    LayerMask layerMask;

    void Start()
    {
        _camera = Camera.main;
        _distanceJoint = GetComponent<DistanceJoint2D>();
        _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.positionCount = 0;
        _distanceJoint.enabled = false;
        isGrapp = true;
    }

    void Update()
    {
        GetMouse();

        RaycastHit2D hit2D = Physics2D.Raycast(_camera.transform.position, grapplePoint, Mathf.Infinity, layerMask);

        if (Input.GetMouseButtonDown(0) && isGrapp && hit2D)
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
        DrawLine();
    }

    void StartGrapple()
    {
        _distanceJoint.enabled = true;
        _distanceJoint.connectedAnchor = grapplePoint;
        _lineRenderer.positionCount = 2;
        tempPoint = grapplePoint;
        isGrapp = false;
    }

    void StopGrapple()
    {
        _distanceJoint.enabled = false;
        isGrapp = true;
        _lineRenderer.positionCount = 0;
    }

    void DrawLine()
    {
        if (_lineRenderer.positionCount <= 0) return;

        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, tempPoint);
    }

    void GetMouse()
    {
        grapplePoint = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}