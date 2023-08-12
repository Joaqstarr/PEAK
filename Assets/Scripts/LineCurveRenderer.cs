using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCurveRenderer : MonoBehaviour
{
    [SerializeField]
    Transform _startPoint;
    public Transform _midPoint;

    public Transform _endPoint;
    [SerializeField]
    LineRenderer _lineRenderer;
    [SerializeField]
    float _vertexCount = 12;
   // MeshFilter _meshFilter;
    // Start is called before the first frame update
    void Start()
    {
       // _meshFilter = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_endPoint == null)
        {
            this.enabled = false;
            return;
        }
        var pointList = new List<Vector3>();
        for(float ratio = 0;ratio <= 1;ratio += 1/_vertexCount)
        {
            var tangent1 = Vector3.Lerp(_startPoint.position, _midPoint.position, ratio);
            var tangent2 = Vector3.Lerp(_midPoint.position, _endPoint.position, ratio);
            var curve = Vector3.Lerp(tangent1, tangent2, ratio);


            pointList.Add(curve);
        }

        _lineRenderer.positionCount = pointList.Count;
        _lineRenderer.SetPositions(pointList.ToArray());
       // GameObject line = new GameObject();
        //Mesh mesh = new Mesh();
       //     _lineRenderer.BakeMesh(mesh, false);
       // _meshFilter.mesh = mesh;
    }
    private void OnEnable()
    {
        _lineRenderer.enabled = true;
    }
    private void OnDisable()
    {
        _lineRenderer.enabled = false ;

    }
}
