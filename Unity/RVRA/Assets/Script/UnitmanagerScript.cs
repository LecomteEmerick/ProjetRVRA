using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitmanagerScript : MonoBehaviour {

    public List<UnitClass> _unitsInfos;
    public GameObject point1;
    public GameObject point2;

    public int maxTimeSpawn = 10;

    private bool canSpawnUnit;
    private NavMeshPath pathToPointOne;
    private NavMeshPath pathToPointTwo;

    void Start()
    {
        pathToPointOne = new NavMeshPath();
        pathToPointTwo = new NavMeshPath();
        NavMesh.CalculatePath(point2.transform.position, point1.transform.position, -1, pathToPointOne);
        NavMesh.CalculatePath(point1.transform.position, point2.transform.position, -1, pathToPointTwo);
    }

    public void EnableSpawnUnit()
    {
        this.canSpawnUnit = true;
        StartCoroutine(randomSpawnUnit());
    }

    public void DisableSpawnUnit()
    {
        this.canSpawnUnit = false;
        StopCoroutine(randomSpawnUnit());
    }

    public void allUnitsToSpawn()
    {
        foreach (UnitClass unitInfos in _unitsInfos)
        {
            unitInfos.changeUnitPosition(unitInfos.Spawn.transform.position);
        }
    }

    private IEnumerator randomSpawnUnit()
    {
        int second = (int)(Random.value * maxTimeSpawn);
        yield return new WaitForSeconds(second);
        spawnUnit();
        StartCoroutine(randomSpawnUnit());
    }

    public void spawnUnit()
    {
        UnitClass selectedUnit = selectAvailibleUnit();

        if (selectedUnit == null) { return; }

        NavMeshPath path = new NavMeshPath();

        if(Random.value < 0.5f)
        {
            selectedUnit.changeUnitPosition(point1.transform.position);
            selectedUnit.setTarget(point2);
            selectedUnit.isAvailible = false;
            selectedUnit.NavMesh.path = pathToPointTwo;
            StartCoroutine(cooldownRest(selectedUnit));
        }
        else
        {
            selectedUnit.changeUnitPosition(point2.transform.position);
            selectedUnit.setTarget(point1);
            selectedUnit.isAvailible = false;
            selectedUnit.NavMesh.path = pathToPointOne;
            StartCoroutine(cooldownRest(selectedUnit));
        }
    }

    private UnitClass selectAvailibleUnit()
    {
        int i=0;
        UnitClass selectedUnit = null;
        while(i < this._unitsInfos.Count && selectedUnit == null)
        {
            if (this._unitsInfos[i].isAvailible)
                selectedUnit = this._unitsInfos[i];
            i++;
        }
        return selectedUnit;
    }

    public void destroyUnit(GameObject sender, GameObject unit)
    {
        int i=0;
        UnitClass myUnitInfos = null;
        while(i < this._unitsInfos.Count && myUnitInfos == null)
        {
            if(unit == this._unitsInfos[i].Unit)
            {
                myUnitInfos = this._unitsInfos[i];
            }
            i++;
        }
        if(myUnitInfos != null && myUnitInfos.getTarget() == sender)
        {
            myUnitInfos.changeUnitPosition(myUnitInfos.Spawn.transform.position);
            resetNavMesh(myUnitInfos);
            myUnitInfos.isAvailible = true;
        }
    }

    private IEnumerator cooldownRest(UnitClass unit)
    {
        yield return new WaitForSeconds(15);
        resetOneUnit(unit);
    }

    private void resetOneUnit(UnitClass unit)
    {
        Debug.Log("AutoReset");
        if(!unit.isAvailible)
        {
            unit.changeUnitPosition(unit.Spawn.transform.position);
            resetNavMesh(unit);
            unit.isAvailible = true;
        }
    }

    public void resetUnit()
    {
        int i = 0;
        UnitClass myUnitInfos = null;
        while (i < this._unitsInfos.Count && myUnitInfos == null)
        {
            if (!this._unitsInfos[i].NavMesh.enabled)
            {
                myUnitInfos = this._unitsInfos[i];
            }
            i++;
        }
        if (myUnitInfos != null)
        {
            myUnitInfos.changeUnitPosition(myUnitInfos.Spawn.transform.position);
            resetNavMesh(myUnitInfos);
            myUnitInfos.isAvailible = true;
        }
    }

    private void resetNavMesh(UnitClass myUnitInfos)
    {
        //myUnitInfos.NavMesh.Stop(true);
        myUnitInfos.NavMesh.ResetPath();
        myUnitInfos.Unit.rigidbody.velocity = Vector3.zero;
    }
}
