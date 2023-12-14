using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AI_PathPoint : MonoBehaviour
{
    public List<GameObject> _listPoint;
    private Transform _nextPosition;
    private int _indexList = 0;
    public Transform Next { get => _nextPosition; set => _nextPosition = value; }
    public int Index { get => _indexList; set => _indexList = value; }

    public void ChangePoint()
    {
        if(_indexList == _listPoint.Count - 1)
        {
            _indexList = 0;
        }
        else
        {
            _indexList++;
        }
        //Debug.Log(_indexList + " "+ _listPoint.Count);
        _nextPosition.position = _listPoint[_indexList].transform.position;
    }




}
