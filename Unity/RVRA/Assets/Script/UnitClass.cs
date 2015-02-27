using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UnitClass : MonoBehaviour
{
    public GameObject Unit;
    public GameObject Spawn;
    public NavMeshAgent NavMesh;

    public bool isAvailible = true;

    private GameObject target;

    public UnitClass(GameObject unit, GameObject spwan, NavMeshAgent NavMesh)
    {
        this.Unit = unit;
        this.Spawn = spwan;
        this.NavMesh = NavMesh;
    }

    public void disableNavMesh()
    {
        this.NavMesh.enabled = false;
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }

    public GameObject getTarget()
    {
        return this.target;
    }

    public void changeUnitPosition(Vector3 newPosition)
    {
        this.NavMesh.enabled = false;
        this.Unit.transform.position = newPosition;
        this.NavMesh.enabled = true;
    }
}
