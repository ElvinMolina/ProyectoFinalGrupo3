using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFloorController : MonoBehaviour
{

    private CharacterController player;

    public string groundName;
    public Vector3 groundPosition;
    public string lastGroundName;
    public Vector3 lastGroundPosition;

    Quaternion actualRot;
    Quaternion lastRot;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.isGrounded)
        {
            // RaycastHit hit;
            // if (Physics.Raycast(transform.position, Vector3.down, out hit))
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, player.height / 4.2f, -transform.up, out hit))
            {
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;

                actualRot = groundedIn.transform.rotation;

                if (groundPosition != lastGroundPosition && groundName == lastGroundName)
                {
                    this.transform.position += (groundPosition - lastGroundPosition);
                }

                // if (actualRot != lastRot && groundName == lastGroundName)
                // {
                //     var newRot = this.transform.rotation * (actualRot.eulerAngles - lastRot.eulerAngles);
                //     transform.RotateAround(groundedIn.transform.position, Vector3.up, newRot.y);
                // }

                lastGroundName = groundName;
                lastGroundPosition = groundPosition;
            }
        }
        else
        {
           lastGroundName = null;
           lastGroundPosition = Vector3.zero;
        }

    }

    private void OnDrawGizmos()
    {
       player = GetComponent<CharacterController>();
       Gizmos.DrawWireSphere(transform.position, player.height / 4.2f);
    }

}
