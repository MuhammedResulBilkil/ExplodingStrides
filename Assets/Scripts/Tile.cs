using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public UnitState UnitState => _unitState;
    private UnitState _unitState;
    public MeshRenderer MyMeshRenderer;
    private GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    public void Prepare(UnitState state)
    {
        _unitState = state;
    }
    public void OnTileClick()
    {
        if (gridManager.IsGameOver())
        {
            return; // Oyun bitmi�se t�klamalar devre d���
        }
        if (_unitState == UnitState.Mine)
        {
            Debug.Log("May�na t�kland�");
            gridManager.GameOver();
        }
        else
        {
            Debug.Log("May�na t�klanmad�");
        }
    }
}
    public enum UnitState
    {
        Empty,
        Mine
    }