using UnityEngine;

public class DontGoThroughThings : MonoBehaviour
{
	// Careful when setting this to true - it might cause double
	// events to be fired - but it won't pass through the trigger
	public bool sendTriggerMessage = false;

	public LayerMask layerMask = -1; //make sure we aren't in this layer 
	public float skinWidth = 0.1f; //probably doesn't need to be changed 

	private float minimumExtent;
	private float partialExtent;
	private float sqrMinimumExtent;
	private Vector3 previousPosition;
	private Transform myTransform;
	private Collider myCollider;

	//initialize values 
	void Awake()
	{
		myTransform = transform;
		myCollider = GetComponent<Collider>();
		minimumExtent = Mathf.Min(Mathf.Min(myCollider.bounds.extents.x, myCollider.bounds.extents.y),
			myCollider.bounds.extents.z);
		partialExtent = minimumExtent * (1.0f - skinWidth);
		sqrMinimumExtent = minimumExtent * minimumExtent;
	}

	private void OnEnable()
	{
		previousPosition = myTransform.position;
	}

	void FixedUpdate()
	{
		//have we moved more than our minimum extent? 
		Vector3 movementThisStep = myTransform.position - previousPosition;
		float movementSqrMagnitude = movementThisStep.sqrMagnitude;

		if (movementSqrMagnitude > sqrMinimumExtent)
		{
			float movementMagnitude = Mathf.Sqrt(movementSqrMagnitude);
			RaycastHit hitInfo;

			//check for obstructions we might have missed 
			if (Physics.Raycast(previousPosition, movementThisStep, out hitInfo, movementMagnitude, layerMask.value))
			{
				if (!hitInfo.collider)
					return;

				if (!hitInfo.collider.isTrigger)
					myTransform.position = hitInfo.point - (movementThisStep / movementMagnitude) * partialExtent;

			}
		}

		previousPosition = myTransform.position;
	}
}