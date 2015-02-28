using UnityEngine;
using System.Collections;

public class ballManagerScript : MonoBehaviour {

    [SerializeField]
    private GameObject _ball;

    [SerializeField]
    private Vector3 _origin;

    [SerializeField]
    private int speed = 1;

	// Use this for initialization
	void Start () {
        
	}

    public void LaunchBall()
    {
        this._ball.transform.position = this._origin;
        this._ball.rigidbody.velocity = Vector3.zero;
        this._ball.rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        StartCoroutine(wait(3));
    }

    private IEnumerator wait(int seconde)
    {
        yield return new WaitForSeconds(seconde);
        this._ball.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        AddRandomForce();
        
    }

    private void AddRandomForce()
    {
        int zForces = 1;
        if(Random.value < 0.5)
            zForces = -zForces;
        int xForces = 1;
        if (Random.value < 0.5)
            xForces = -xForces;
        this._ball.rigidbody.velocity = new Vector3(xForces, 0, zForces).normalized * speed;
    }

    public void InverseXForces(int sideInverseValue)
    {
        Vector3 currentForces = this._ball.rigidbody.velocity;
        int x = sideInverseValue;
        /*float y = -0.33f;
        if (currentForces.y == 0)
            y = 1;*/
        int z = currentForces.z >= 0 ? 1 : -1;
        this._ball.rigidbody.velocity = new Vector3(x , 0, z).normalized * speed;
    }

    public void InverseYForces(int sideInverseValue)
    {
        Vector3 currentForces = this._ball.rigidbody.velocity;
        int x = currentForces.x >= 0 ? 1 : -1;
        int y = sideInverseValue;
        int z = currentForces.z >= 0 ? 1 : -1;
        this._ball.rigidbody.velocity = new Vector3(x, y, z).normalized * speed;
    }

    public void InverseZForces(int sideInverseValue)
    {
        //Debug.Log("Collision");
        Vector3 currentForces = this._ball.rigidbody.velocity;
        int x = currentForces.x >= 0 ? 1 : -1;
        /*float y = -0.33f;
        if (currentForces.y == 0)
            y = 1;*/
        int z = sideInverseValue;
        this._ball.rigidbody.velocity = new Vector3(x, 0, z).normalized * speed;
    }
}
