using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGun : MonoBehaviour
{
    [SerializeField] Transform _camOffset;
    public GameObject _selected;
    [SerializeField] LayerMask _grabbable;
    [SerializeField] Material _outlineMat;
    [SerializeField] Material _selectMat;
    [SerializeField] LineCurveRenderer _line;
    [SerializeField] Transform _midpoint;
    SpringJoint _joint;
    bool _isFiring = false;
    PlayerControls _input;
    PlayerData _data;
    [SerializeField] SpringJoint _grappleJoint;
    float _storedDrag = 0;
    public bool _grapple = false;
    [SerializeField]
    Animator _anim;
    [SerializeField]
    Material _transparentMat;
    // Start is called before the first frame update
    void Start()
    {
        _joint = GetComponent<SpringJoint>();
        _input = GameObject.Find("Player").GetComponent<PlayerControls>();
        _data = _input._data;
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerVelocity = _input.GetComponent<Rigidbody>().velocity;
        playerVelocity.y = 0;
        _anim.SetFloat("Speed", playerVelocity.magnitude);

        CheckForTargets();
        _anim.SetBool("Firing", _isFiring);
        if(_input._fireHeld && !_isFiring && _selected != null)
        {
            _isFiring = true;
            GrabObject(_selected);
        }
        if(!_input._fireHeld && _isFiring)
        {
            _isFiring = false;
            LetGo(_selected);
            _selected = null;
        }
        if (_isFiring)
        {
            Holding(_selected);
        }
    }

    public void CheckForTargets()
    {
        if (_isFiring) return;

        RaycastHit hit;

        if (Physics.Raycast(_camOffset.position, _camOffset.forward, out hit, _data.maximumRange, _grabbable))
        {
            if (hit.collider.GetComponent<Rigidbody>() != null && hit.collider.CompareTag("Grabbable"))
            {
                if (_selected != hit.collider.gameObject )
                {
                    if (_selected != null) AddMat(_selected, _transparentMat);
                    _selected = hit.collider.gameObject;

                    AddMat(_selected, _outlineMat);
                }



            }
            else
            {
                if (_selected != null)
                {


                    AddMat(_selected, _transparentMat);

                }
                _selected = null;
            }
        }
        else
        {
            if (_selected != null)
            {
                AddMat(_selected, _transparentMat);

            }
            _selected = null;
        }
    }
    void AddMat(GameObject targ, Material mat)
    {
        MeshRenderer renderer = targ.GetComponent<MeshRenderer>();
        if (renderer == null) renderer = targ.GetComponentInChildren<MeshRenderer>();
        Material[] mats = renderer.materials;
        mats[mats.Length - 1] = mat;

        renderer.materials = mats;


    }

    void GrabObject(GameObject targ)
    {
        AddMat(targ, _selectMat);
        _grapple = targ.GetComponent<Rigidbody>().mass > _data.grappleMassThreshold;

        if (_grapple)
        {
            _joint.anchor = new Vector3(0, 0, Vector3.Distance(transform.position, targ.transform.position));


            _grappleJoint = _input.gameObject.AddComponent<SpringJoint>();
            _grappleJoint.connectedBody = targ.GetComponent<Rigidbody>();
            _grappleJoint.spring = _data.springAmount;
            _grappleJoint.damper = _data.damper;
            _grappleJoint.minDistance = _data.minMaxDist.x;
            _grappleJoint.maxDistance = _data.minMaxDist.y;
            _grappleJoint.enableCollision = true;
            _grappleJoint.autoConfigureConnectedAnchor = false;
            _grappleJoint.connectedAnchor = Vector3.zero;
            _grappleJoint.tolerance = 0;
            _grappleJoint.breakForce = Mathf.Infinity;
            _grappleJoint.breakTorque = Mathf.Infinity;
            _grappleJoint.massScale = 1;
            _grappleJoint.connectedMassScale = 1;
            _grappleJoint.enablePreprocessing = true;



        }
        else
        {
            _joint.anchor = new Vector3(0, 0, Vector3.Distance(transform.position, targ.transform.position));
            if(_grappleJoint != null)
            {
                Destroy(_grappleJoint);
            }

        }

        Vector3.Distance(transform.position, targ.transform.position);
        _joint.connectedBody = targ.GetComponent<Rigidbody>();
        _line.enabled = true;
        _line._endPoint = targ.transform;
        _storedDrag = targ.GetComponent<Rigidbody>().drag;
        targ.GetComponent<Rigidbody>().drag = 4;

        _midpoint.localPosition = _joint.anchor;

    }


    private void LetGo(GameObject targ)
    {
        _joint.connectedBody = null;
        _line.enabled = false;

        AddMat(targ, _transparentMat);
        targ.GetComponent<Rigidbody>().drag = _storedDrag;
        if (_grappleJoint != null)
        {
            Destroy(_grappleJoint);
        }
    }

    void Holding(GameObject targ)
    {
        _midpoint.localPosition = _joint.anchor;
        if (_grapple)
        {
            _joint.anchor = new Vector3(0, 0, Vector3.Distance(transform.position, targ.transform.position));
             _grappleJoint.maxDistance = Mathf.Clamp(_grappleJoint.maxDistance + (_input._reelValue * _data.scrollSpeed * Time.deltaTime), _data.minimumRange, _data.maximumRange);

            // _grappleJoint.maxDistance = 2f;
              Debug.Log(_grappleJoint.maxDistance);

        }
        else
        {
            _joint.anchor = new Vector3(0, 0, Mathf.Clamp(_joint.anchor.z + (_input._reelValue * _data.scrollSpeed * Time.deltaTime), _data.minimumRange, _data.maximumRange));

        }

    }
}
