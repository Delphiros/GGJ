#if UNITY_EDITOR
using UnityEngine;

public class FlipPrefab : MonoBehaviour
{
    [SerializeField] 
    private bool _isStart;

    [SerializeField]
    private bool _isFlipHorizontal;

    [SerializeField]
    private Transform _shadowTransform;

    private void OnValidate()
    {
        if (!_isStart)
        {
            return;
        }

        // Base Object
        Vector3 localRotation = transform.localEulerAngles;
        float localRotationY = _isFlipHorizontal ? 180 : 0;
        transform.localRotation = Quaternion.Euler(localRotation.x, localRotationY, localRotation.z);

        // Shadow Object
        if (_shadowTransform != null)
        {
            Vector3 shadowRotation = _shadowTransform.localEulerAngles;
            float shadowRotationX = _isFlipHorizontal ? 90 + 20 : 90 - 20;
            _shadowTransform.localRotation = Quaternion.Euler(shadowRotationX, shadowRotation.y, shadowRotation.z);
        }
    }
}
#endif