using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class OnCollisionWithObjectFireEventScript : MonoBehaviour {

    [SerializeField]
    private GameObject _object;

    [SerializeField]
    private UnityEvent eventToFire;

    private int _layerObject;

    void Start()
    {
        if (eventToFire == null)
            Debug.Log("Aucun event renseigné.");
        _layerObject = this._object.layer;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _layerObject)
            if (eventToFire != null)
                eventToFire.Invoke();
    }
}
