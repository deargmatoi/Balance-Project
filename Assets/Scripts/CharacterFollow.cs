using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollow : MonoBehaviour
{
    [SerializeField] private Transform followedObj;

    private void Follow()
    {
       
        transform.position = followedObj.position - new Vector3(0,.5f,0);
    }


    private void LateUpdate()
    {
        Follow();
    }
}
