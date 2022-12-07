using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicingBlade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MeshCut.Cut(other.gameObject.transform, transform.position);
    }
}
