using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Tools;
using UnityEngine;
public class CinemachineFader : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cmCamera;
    [SerializeField] private LayerMask cullingMask;
    [SerializeField] private Material cullingMaterial;
    [SerializeField] private float cameraRadius = 2;
    private Vector3 startPos => cmCamera ? cmCamera.transform.position : Vector3.zero;
    private Vector3 endPos => cmCamera?.Follow ? cmCamera.Follow.position : Vector3.zero;
    private RayCaster rayCaster = new();
    private void Start()
    {
        Material[] lastCullingMaterials = null;
        List<Material> cullingList = new();
        rayCaster.OnRayEnter += hit =>
        {
            var meshRenderer = hit.transform?.GetComponent<MeshRenderer>();
            if (meshRenderer == null) return;
            cullingList.Resize(meshRenderer.materials.Length, cullingMaterial);
            lastCullingMaterials = meshRenderer.materials;
            meshRenderer.materials = cullingList.ToArray();
        };
        rayCaster.OnRayExit += hit =>
        {
            var meshRenderer = hit.transform.GetComponent<MeshRenderer>();
            if (meshRenderer == null || lastCullingMaterials == null) return;
            meshRenderer.materials = lastCullingMaterials;
        };
    }
    private void Update()
    {
        if (rayCaster.ColliderExist(startPos, endPos, cullingMask)) rayCaster.Cast(startPos, endPos, cullingMask);
        else rayCaster.Cast(endPos, startPos, cullingMask);
        // rayCaster.Cast(startPos +, endPos, cullingMask);
    }
}
