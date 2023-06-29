using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Color _normalColor;
    [SerializeField] private float _positionOffset = 0.6f;

    private GameObject _turretToBuild;
    private GameObject _turret;
    private Renderer _renderer;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _normalColor = _renderer.material.color;
    }


    #region OnMouseFunctions
    private void OnMouseDown()
    {
        if (_turret != null)
        {
            Debug.Log("THERE IS A ALREADY HAS A TURRET YOU IDIOT");
            return;
        }
        _turretToBuild = BuildManager.Instance.GetTurretToBuild();
        var position = transform.position;
        position = new Vector3(position.x, position.y + _positionOffset, position.z);
        _turret = (GameObject)Instantiate(_turretToBuild, position, transform.rotation);
    }

    private void OnMouseEnter()
    {
        _renderer.material.color = _hoverColor;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _normalColor;
    }
    #endregion
}
