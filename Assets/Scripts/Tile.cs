using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public UnitState UnitState => _unitState;
    private UnitState _unitState;
    public MeshRenderer MyMeshRenderer;

    private bool isGameOver = false; // Oyunun bitti mi?

    public void Prepare(UnitState state)
    {
        _unitState = state;
       // MyMeshRenderer.material.color = _unitState == UnitState.Mine ? Color.red : Color.green;
    }
    public void OnTileClick()
    {
        if (isGameOver)
        {
            return; // Oyun bitmi�se t�klamalar devredisi
        }
        else if (_unitState == UnitState.Mine)
        {
            Debug.Log("May�na t�kland�!");
            GameOver();
        }
        else
        {
            Debug.Log("May�na t�klanmad�!");
        }
    }

    private void GameOver()
    {
        // Oyunu bitirme i�lemleri burada yap�labilir
        isGameOver = true;
        Debug.Log("Oyun bitti!");
    }
}
    public enum UnitState
    {
        Empty,
        Mine
    }