using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObjects : MonoBehaviour
{
    public bool isAutomatic;

    private void Update()
    {
        if (!isAutomatic)
        {
            var colliders = Physics.OverlapBox(transform.position, transform.localScale);

            foreach (var item in colliders)
            {
                if (item != null && !item.CompareTag("Belt"))
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        SliceObj(item);
                    }
                }
            }
        }
    }

    public SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        // slice the provided object using the transforms of this object
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }

    private void SliceObj(Collider other)
    {
        Material crossMat = other.GetComponent<MeshRenderer>().sharedMaterial;
        SlicedHull hull = SliceObject(other.gameObject, crossMat);
        if (hull != null)
        {
            hull.CreateLowerHull(other.gameObject, crossMat);
            hull.CreateUpperHull(other.gameObject, crossMat);
            Debug.Log("Executed");
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Belt") && isAutomatic)
        {
            SliceObj(other);
        }
    }
}
