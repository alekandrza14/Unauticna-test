using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity1 : MonoBehaviour
{
    public float gravity;
    public Transform body;
    private void Update()
    {
        Arract();
    }
    // Start is called before the first frame update
    public void Arract()
    {
        Vector3 gravityUp = (body.position - Vector3.zero).normalized;
        Vector3 bodyup = body.up;
        
                body.gameObject.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);
           
            Quaternion targetrotation = Quaternion.FromToRotation(bodyup,gravityUp)*body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetrotation,50 * Time.deltaTime);
    }
}
