using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mouse : MonoBehaviour
{
    public static GameObject SelectedObject { get; private set; }
    public static Vector3 Position => _mouse.position;

    public static event UnityAction<GameObject> SelectedObjectChanged;
    public static event UnityAction<GameObject> ObjectClicked;

    private static Transform _mouse;

    private void Start()
    {
        _mouse = transform;
    }

    private void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            _mouse.position = hit.point;
            if (SelectedObject != hit.collider.gameObject)
            {
                SelectedObject = hit.collider.gameObject;
                SelectedObjectChanged?.Invoke(SelectedObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            ObjectClicked?.Invoke(SelectedObject);
    }
}
