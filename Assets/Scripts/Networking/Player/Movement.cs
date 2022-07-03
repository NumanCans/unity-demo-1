using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class Movement : MonoBehaviourPun
{
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Forward;
    public KeyCode Backward;


    [SerializeField]
    private float MoveSpeed = 50;

    private Rigidbody body;
    private Animator anim;
    public GameObject cam;
    public Transform head;
    public Transform headLock;
    public Vector3 HeadOffset;
    public Transform GunHoldOne;
    public float AnimationSpeed;

    GunManager gm;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gm = GetComponent<GunManager>();
        //cam = gameObject.transform.GetChild(0).gameObject;

        if(photonView.IsMine)
        {
            cam.SetActive(true);

        }
        anim.SetFloat("Move", 0);


    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        anim.SetIKPosition(AvatarIKGoal.RightHand, GunHoldOne.transform.position);

        //anim.SetLookAtWeight(1);
        //anim.SetLookAtPosition(cam.transform.position);
    }

    private void LateUpdate()
    {
        Quaternion rot = Quaternion.Euler(headLock.transform.eulerAngles.x, headLock.transform.eulerAngles.y, -cam.transform.eulerAngles.x) * Quaternion.Euler(HeadOffset);
        head.transform.rotation = rot;
    }



    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            if(Input.GetKey(Left))
            {
                anim.SetFloat("Move", Mathf.Lerp(anim.GetFloat("Move"), .5f, AnimationSpeed * Time.deltaTime));
                body.AddRelativeForce(Vector3.left * MoveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
            else if(Input.GetKeyUp(Left))
            {
                anim.SetFloat("Move", 0);

            }
            if (Input.GetKey(Right))
            {
                anim.SetFloat("Move", Mathf.Lerp(anim.GetFloat("Move"), .5f, AnimationSpeed * Time.deltaTime));
                body.AddRelativeForce(Vector3.left * -MoveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
            else if (Input.GetKeyUp(Right))
            {
                anim.SetFloat("Move", 0);

            }
            if (Input.GetKey(Forward))
            {
                anim.SetFloat("Move", Mathf.Lerp(anim.GetFloat("Move"), .5f, AnimationSpeed * Time.deltaTime));
                body.AddRelativeForce(Vector3.forward * MoveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
            else if (Input.GetKeyUp(Forward))
            {
                anim.SetFloat("Move", 0);


            }
            if (Input.GetKey(Backward))
            {
                anim.SetFloat("Move", Mathf.Lerp(anim.GetFloat("Move"), .5f, AnimationSpeed * Time.deltaTime));

                body.AddRelativeForce(Vector3.forward * -MoveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
            else if (Input.GetKeyUp(Backward))
            {
                anim.SetFloat("Move", 0);


            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetFloat("Move", Mathf.Lerp(anim.GetFloat("Move"), 1, AnimationSpeed * Time.deltaTime));

                body.AddRelativeForce(Vector3.forward * (MoveSpeed +30) * Time.deltaTime, ForceMode.Impulse);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetFloat("Move",0);


            }

            gameObject.transform.Rotate(new Vector3(0, x, 0));
            cam.transform.Rotate(new Vector3(-y, 0, 0));
            gm.HoldPosition.transform.Rotate(new Vector3(-y, 0, 0));
        }
        
    }
}
