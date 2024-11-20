using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net.Sockets;
using SCIP_library;
using Unity.VisualScripting;

public class MoveCube3_copy : MonoBehaviour
{
    [SerializeField] private GameObject _cube; // Cubeオブジェクトの参照
    [SerializeField] private ParticleSystem _particleSystem; // パーティクルシステムの参照
    [SerializeField] private int _distanceGap = 100;
    [SerializeField] private int _minSize = 20;
    [SerializeField] private int _maxSize = 150;
    [SerializeField] private Vector2 _offsetXY_mm = Vector2.zero;
    [SerializeField] private float _offsetRot_deg = 0f;

    public URGSensor _urg; // URGセンサー

    private float step_time;    // 経過時間カウント用

    public bool _calibrated;
    public bool _objectDetected = false;
    public bool _objectNotDetected = false;
    public Vector3 p { get; private set; }
    public Vector3 pp { get; private set; }

    private Mesh _mesh;
    private List<Vector3> _vertices;
    private List<int> _triangles;
    [SerializeField] private Material _mat;

    private float timer = 0f;  // Timer to track elapsed time
    private bool hasExecuted = false;

    void Start()
    {
        _urg = new URGSensor();
        _urg.OpenStream("192.168.0.10", 0, 2160);
        _calibrated = false;
        _objectDetected = false;
        

        var meshFilter = gameObject.AddComponent<MeshFilter>();
        var meshRenderer = gameObject.AddComponent<MeshRenderer>();
        _mesh = meshFilter.mesh;
        _mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        //meshRenderer.sharedMaterial = _mat;

        _mesh.Clear();

        var step = _urg.Steps;
        _vertices = new List<Vector3>();
        for (int i = 0; i < step; i++)
        {
            _vertices.Add(Vector3.zero);
        }
        _vertices.Add(Vector3.zero);
        _mesh.SetVertices(_vertices);

        _triangles = new List<int>();
        for (int i = 0; i < step - 1; i++)
        {
            _triangles.Add(_vertices.Count - 1);
            _triangles.Add(i + 1);
            _triangles.Add(i);
        }
        _mesh.SetTriangles(_triangles, 0);
        
            
        
    }

    void Update()
    {
        
            if (!hasExecuted) {
        timer += Time.deltaTime;  // Increment timer by time passed since last frame
        
        if (timer >= 0.1f) {  // Check if 1 second has passed
            _urg.StoreCalibrationData(); // キャリブレーションデータを保存 
            _calibrated = true; // キャリブレーションが完了したとマーク
            //_mesh.Clear(); // メッシュをクリア

            hasExecuted = true;  // Set flag to true so the code doesn't run again
        }
            }

        transform.localPosition = new Vector3(_offsetXY_mm.x, _offsetXY_mm.y, 0f) / 1000f;
        transform.localEulerAngles = new Vector3(0f, 0f, _offsetRot_deg + 180f);

        _urg.SetDetectParam(_distanceGap, _minSize, _maxSize);
        _urg.Pose = transform.localToWorldMatrix;

        if (_calibrated == false)
        {
            var distance = _urg.Distances;
            for (int i = 0; i < distance.Length; i++)
            {
                _vertices[i] = _urg.CalcRawPos(i);
            }
            _mesh.SetVertices(_vertices);
            _mesh.RecalculateBounds();
            _mesh.RecalculateNormals();
        }

        var objs = _urg.Objs;
        if (objs != null && objs.Length > 0)
        {
            _objectDetected = true;
            var detectedObject = objs[0];
            pp = new Vector3(detectedObject.x, detectedObject.y, detectedObject.z); // 検出したオブジェクトの位置で pp を更新
            MoveCubeAtPosition(pp);
            _cube.SetActive(true);

            // パーティクルを再生
            if (_particleSystem != null && !_particleSystem.isPlaying)
            {
                _particleSystem.Play();
            }
        }
        else
        {
            _objectDetected = false;
            _objectNotDetected = true;
            _cube.SetActive(false);

            // パーティクルを停止
            if (_particleSystem != null && _particleSystem.isPlaying)
            {
                _particleSystem.Stop();
            }
        }
    }

    void MoveCubeAtPosition(Vector3 position)
    {
        if (_cube != null)
        {
            _cube.transform.position = position;
        }
    }

    private void OnDestroy()
    {
        if (_urg != null)
        {
            _urg.CloseStream();
        }
    }
}