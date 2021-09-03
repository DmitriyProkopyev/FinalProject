using UnityEngine;
using System.Linq;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    public Vector3[] Points => _points.Select(point => point.position).ToArray();
}
