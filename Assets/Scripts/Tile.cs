using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    public UnitState UnitState => _unitState;
    private UnitState _unitState;
    public MeshRenderer MyMeshRenderer;
    private GridManager gridManager;
    public TileController tileController;
    public int x;
    public int y;
    public TextMeshPro mineCountText;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }


    public void GetCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;

    }

    public void Prepare(UnitState state)
    {
        _unitState = state;
    }
    public void OnTileClick()
    {
        print("tile�n ontileclicki");
        //tileController.CalculateMineNeighborMineCounts();
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

            
            //TileController tileController = GetComponent<TileController>();
            //tileController.PrintNeighborMineCounts(x,y);

            //TileController controllerInstance = new TileController();
          //  int neighborMineCount = controllerInstance.CalculateNeighborMineCount(x, y);

           int neighborMineCount = tileController.CalculateNeighborMineCount(x, y);
            mineCountText.text = neighborMineCount.ToString();
            //int neighborMineCount = tileController.CalculateNeighborMineCount(transform.position.x, transform.position.z);
            // mineCountText.text = tileController.neighborMineCount.ToString();
        }
    }
}
    public enum UnitState
    {
        Empty,
        Mine
    }

