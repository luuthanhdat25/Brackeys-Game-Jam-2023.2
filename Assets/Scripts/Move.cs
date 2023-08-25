using System.Collections;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float gridSize = 1f; 
    private bool isMoving = false; 
    
    private void Update()
    {
        if (!isMoving && Input.GetMouseButton(0))
        {
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; 

            Vector3 targetPosition = new Vector3(
                Mathf.Round(mousePosition.x / gridSize) * gridSize,
                Mathf.Round(mousePosition.y / gridSize) * gridSize,
                0f
            );
            StartCoroutine(MoveToTarget(targetPosition));
        }
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition)
    {
        isMoving = true;

        Vector3 direction = (targetPosition - transform.position).normalized;
        while (Vector3.Distance(transform.position, targetPosition) > gridSize)
        {
            transform.position += direction * gridSize;
            yield return new WaitForSeconds(moveSpeed);
        }

        isMoving = false;
    }



}