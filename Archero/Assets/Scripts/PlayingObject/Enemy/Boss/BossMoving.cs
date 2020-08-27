using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BossMoving : MovingBase
{
    Vector3 destination;
    Transform playerTransform;
    bool lookAtDestination = false;
    private void OnEnable()
    {
        playerTransform = GameManager.instance.player.transform;
    }
    public IEnumerator SetDestination(float timeToMove)
    {
        lookAtDestination = true;
        destination = playerTransform.position;
        yield return StartCoroutine(MoveOverSeconds(gameObject, destination, timeToMove));
    }
    public override void UpdateNormal()
    {
        if (lookAtDestination)
            transform.LookAt(destination);
    }
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
        lookAtDestination = false;
    }
}
