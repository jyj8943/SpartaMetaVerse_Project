using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlaneObstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holsSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    private FlappyPlaneManager flappyPlaneManager;

    private void Start()
    {
        flappyPlaneManager = FlappyPlaneManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holsSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;
        
        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FlappyPlanePlayer player = collision.GetComponent<FlappyPlanePlayer>();
        if (player != null)
        {
            flappyPlaneManager.AddScore(1);
        }
    }
}
