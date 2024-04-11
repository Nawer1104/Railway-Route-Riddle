using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].train.MoveToTarget(transform.position);
    }
}
