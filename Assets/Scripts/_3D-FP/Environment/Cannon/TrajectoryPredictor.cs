using StudyProj.Environment.Cannon;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryPredictor : MonoBehaviour
{
    [SerializeField] private Transform _hitMarker;
    
    [Range(10, 100)]
    [SerializeField] private int _maxPoints = 50;
    
    [Range(0.01f, 0.5f)]
    [SerializeField] private float _increment = 0.025f;
    
    [Range(1.05f, 2f)]
    [SerializeField] private float rayOverlap = 1.1f;
    
    private LineRenderer _trajectoryLine;

    private void Start()
    {
        _trajectoryLine ??= GetComponent<LineRenderer>();

        SetTrajectoryVisible(true);
    }

    public void PredictTrajectory(ProjectileProperties projectile)
    {
        Vector3 velocity =  projectile.Direction * (projectile.InitialSpeed / projectile.Mass);
        Vector3 position = projectile.InitialPosition;

        UpdateLineRender(_maxPoints, (0, position));

        for (int i = 1; i < _maxPoints; i++)
        {
            velocity = CalculateNewVelocity(velocity, projectile.Drag, _increment);
            var nextPosition = position + velocity * _increment;
            var overlap = Vector3.Distance(position, nextPosition) * rayOverlap;

            if (Physics.Raycast(position, velocity.normalized, out RaycastHit hit, overlap))
            {
                UpdateLineRender(i, (i - 1, hit.point));
                MoveHitMarker(hit);
                break;
            }

            _hitMarker.gameObject.SetActive(false);
            position = nextPosition;
            UpdateLineRender(_maxPoints, (i, position));
        }
    }
    
    private void UpdateLineRender(int count, (int point, Vector3 pos) pointPos)
    {
        _trajectoryLine.positionCount = count;
        _trajectoryLine.SetPosition(pointPos.point, pointPos.pos);
    }

    private Vector3 CalculateNewVelocity(Vector3 velocity, float drag, float increment)
    {
        velocity += Physics.gravity * increment;
        velocity *= Mathf.Clamp01(1f - drag * increment);
        return velocity;
    }

    private void MoveHitMarker(RaycastHit hit)
    {
        _hitMarker.gameObject.SetActive(true);

        float offset = 0.025f;
        _hitMarker.position = hit.point + hit.normal * offset;
        _hitMarker.rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
    }

    private void SetTrajectoryVisible(bool visible)
    {
        _trajectoryLine.enabled = visible;
        _hitMarker.gameObject.SetActive(visible);
    }
}