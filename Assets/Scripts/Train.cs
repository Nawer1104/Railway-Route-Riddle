using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Train : MonoBehaviour
{
    private bool isMoving;

    public GameObject vfxCollide;

    private void Awake()
    {
        isMoving = false;
    }

    public void MoveToTarget(Vector3 targetPos)
    {
        if (isMoving) return;

        isMoving = true;

        transform.DOMove(targetPos, 1f).OnComplete(() => {
            isMoving = false;
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Person"))
        {
            GameObject vfx = Instantiate(vfxCollide, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

            collision.gameObject.SetActive(false);
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(collision.gameObject);
            GameManager.Instance.CheckLevelUp();
        }
    }
}
