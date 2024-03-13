using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    public Rigidbody platformRB;
    public Transform[] platformPositions;
    public float platformSpeed;


    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        platformRB.MovePosition(Vector3.MoveTowards(platformRB.position, platformPositions[1].position,platformSpeed * Time.deltaTime));
    }
}
