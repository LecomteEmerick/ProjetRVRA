using UnityEngine;
using System.Collections;

public class UnitReturnToSpawnScript : MonoBehaviour
{
    private int _unitLayer = 9;
    public UnitmanagerScript unitManager;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == _unitLayer)
        {
            unitManager.destroyUnit(gameObject, collision.gameObject);
        }
    }
}
