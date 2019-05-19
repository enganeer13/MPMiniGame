using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class playerTravel : MonoBehaviour
{

    private PhotonView PV;
    private CharacterController myCC;
    public float movementSpeed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PV.IsMine)
        {
            BasicMovement();
        }
    }

    void BasicMovement()
    {
        if(Input.GetKey(KeyCode.D))
        {
            myCC.Move(transform.right * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            myCC.Move(-transform.right * Time.deltaTime * movementSpeed);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            myCC.Move(transform.up * Time.deltaTime * movementSpeed);
        }
    }
}
