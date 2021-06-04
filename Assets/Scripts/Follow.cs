using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject followed;
    public float offset;

    void OnValidate()
    {
        FollowObject();
    }

    // Update is called once per frame
    void Update()
    {
        FollowObject();
    }

    void FollowObject()
    {
        transform.position = new Vector3(followed.transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
