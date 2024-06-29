
using UnityEngine;

namespace W
{
    public class 行 : MonoBehaviour
    {
        public void OnTap()
        {
            Game.Data.UIState = UIState.行;
        }
    }
}
