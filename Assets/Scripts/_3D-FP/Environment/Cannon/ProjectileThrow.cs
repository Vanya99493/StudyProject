using StudyProj.Environment.Cannon;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TrajectoryPredictor))]
public class ProjectileThrow : MonoBehaviour
{
	public InputAction Fire;

	[SerializeField] private Rigidbody _objectToThrow;

	[Range(0.0f, 50.0f)]
	[SerializeField] private float _force;

	[SerializeField] private Transform _startPosition;

	private TrajectoryPredictor _trajectoryPredictor;

	private void OnEnable()
	{
		_trajectoryPredictor = GetComponent<TrajectoryPredictor>();

		_startPosition ??= transform;

		Fire.Enable();
		Fire.performed += ThrowObject;
	}

	private void Update()
	{
		Predict();
	}

	private void Predict()
	{
		_trajectoryPredictor.PredictTrajectory(ProjectileData());
	}

	private ProjectileProperties ProjectileData()
	{
		ProjectileProperties properties = new ProjectileProperties();
		Rigidbody r = _objectToThrow.GetComponent<Rigidbody>();

		properties.Direction = _startPosition.forward;
		properties.InitialPosition = _startPosition.position;
		properties.InitialSpeed = _force;
		properties.Mass = r.mass;
		properties.Drag = r.drag;

		return properties;
	}

	private void ThrowObject(InputAction.CallbackContext ctx)
	{
		Rigidbody thrownObject = Instantiate(_objectToThrow, _startPosition.position, Quaternion.identity);
		thrownObject.AddForce(_startPosition.forward * _force, ForceMode.Impulse);
	}
}