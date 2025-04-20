#if UNITY_EDITOR
using UnityEngine;

public class CalculateTransformPrefab : MonoBehaviour
{
    [SerializeField]
    private bool _isCalculate;

    [SerializeField]
    public float _radius;

    [SerializeField]
    public Transform _circleCenter;

    [SerializeField]
    public Transform[] _transforms;

    void OnValidate()
    {
        if (!_isCalculate)
        {
            return;
        }

        // Calculate distance in each object with center point (Vector2.zero)
        int count = _transforms.Length;
        float[] distances = new float[count];

        for (int i = 0; i < count; i++)
        {
            Vector2 objectsPosition = new Vector2(_transforms[i].position.x, 0);
            float distance = Vector2.Distance(Vector2.zero, objectsPosition);
            distance = _transforms[i].position.x < 0 ? -distance : distance;

            distances[i] = distance;
        }

        // Calculate position and rotation
        for (int i = 0; i < count; i++)
        {
            float radians = distances[i] / _radius;

            // Position
            Vector3 offset = new Vector3(Mathf.Sin(radians), Mathf.Cos(radians), 0) * _radius;
            Vector3 position = _circleCenter.position + offset;
            float positionY = _transforms[i].localPosition.y;
            _transforms[i].position = new Vector3(position.x, position.y, _transforms[i].position.z);
            _transforms[i].localPosition += new Vector3(0, positionY, 0);

            // Rotation
            Vector3 currentRotation = _transforms[i].localEulerAngles;
            float rotationZ = -radians * Mathf.Rad2Deg;
            _transforms[i].localRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, rotationZ);
        }
    }
}
#endif