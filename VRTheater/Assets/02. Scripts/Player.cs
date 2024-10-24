using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform head;
    public Transform left;
    public Transform right;

    Transform headPos;
    Transform leftPos;
    Transform rightPos;

    PhotonView pv;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        XROrigin o = FindObjectOfType<XROrigin>();

        headPos = o.transform.Find("Camera Offset/Main Camera");
        leftPos = o.transform.Find("Camera Offset/Left Controller");
        rightPos = o.transform.Find("Camera Offset/Right Controller");

        if(pv.IsMine)
        {
            foreach(var r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (headPos == null) Debug.Log("headPos null");
        if (leftPos == null) Debug.Log("leftPos null");
        if (rightPos == null) Debug.Log("rightPos null");

        return;

        if (pv.IsMine)
        {
            CopyMove(head, headPos);
            CopyMove(left, leftPos);
            CopyMove(right, rightPos);
        }
    }

    void CopyMove(Transform target, Transform source)
    {
        target.position = source.position;
        target.rotation = source.rotation;
    }
}
