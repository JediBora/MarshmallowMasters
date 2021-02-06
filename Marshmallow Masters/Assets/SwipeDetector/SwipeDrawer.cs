using UnityEngine;

public class SwipeDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private float zOffset = 10;

    //Used for collision of line
    public BoxCollider boxCollider;
    private Vector3 startPos;    // Start position of line
    private Vector3 endPos;    // End position of line


    //The time limit (in seconds)
    public float maxTime;
    //The time (in seconds)
    public float timePassing;

    public bool colliderCreated;

    void Update()
    {
        if (colliderCreated)
        TimerFunction();
    }

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;

    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = Camera.main.ScreenToWorldPoint(new Vector3(data.StartPosition.x, data.StartPosition.y, zOffset));
        positions[1] = Camera.main.ScreenToWorldPoint(new Vector3(data.EndPosition.x, data.EndPosition.y, zOffset));
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(positions);


        startPos = positions[0];
        endPos = positions[1];

        AddColliderToLine();
        colliderCreated = true;
    }


    // Following method adds collider to created line
    private void AddColliderToLine()
    {
        BoxCollider col = new GameObject("Collider").AddComponent<BoxCollider>();

        // Collider is added as child object of line
        col.transform.parent = lineRenderer.transform; 

        // length of line
        float lineLength = Vector3.Distance(startPos, endPos); 

        // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
        col.size = new Vector3(lineLength, 0.1f, 1f); 
        Vector3 midPoint = (startPos + endPos) / 2;

        // setting position of collider object
        col.transform.position = midPoint; 

        // Following lines calculate the angle between startPos and endPos
        float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
        if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
        {
            angle *= -1;
        }
        angle = Mathf.Rad2Deg * Mathf.Atan(angle);
        col.transform.Rotate(0, 0, angle);
    }

    void TimerFunction()
    {
        timePassing += Time.deltaTime;

        if (timePassing >= maxTime)
        {
            timerEnded();
        }
    }
    void timerEnded()
    {
        //Do your stuff here.
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        //Only use if timer needs to be reset
        timePassing = 0;
        colliderCreated = false;
    }


    //Collider Creation in Relation to Line Renderer Credit:
    //http://www.theappguruz.com/blog/add-collider-to-line-renderer-unity

    //Line swipe ting credit:
    //https://www.youtube.com/watch?v=jbFYYbu5bdc&ab_channel=JasonWeimann
}