using System.Collections;
using UnityEngine;

namespace Script
{
    public class RaycastTool : MonoBehaviour
    {
        public LayerMask layerMask;
        [SerializeField] private GameArea _gameArea;
        private bool IsWorking;
        private RaycastHit2D[] hits;
        void Update()
        {
            var left = _gameArea.GetBorderPositionHorizontal().x;
            var up = _gameArea.GetBorderPositionVertical().y;
            Vector2 startingPoint = new Vector2(left, up);
            var direction = Vector2.right;
            RaycastHit2D[] hits = Physics2D.RaycastAll(startingPoint, direction, 10f);

            if (hits.Length == 0) return;
            if(IsWorking) return;
            IsWorking = true;
            StartCoroutine(CheckList());
        }

        private IEnumerator CheckList()
        {
            yield return new WaitForSeconds(2);
            if (hits.Length > 0)
            {
                GameManager.Instance.GameOver();
            }
            IsWorking = false;
        }
    }
}