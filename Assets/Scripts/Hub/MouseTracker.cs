using UnityEngine;
using UnityEngine.InputSystem;

public class MouseTracker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _target;

    private void Update()
    {
        Vector3 screenMousePosition = Mouse.current.position.ReadValue();
        _target.position = screenMousePosition;
    }
}
