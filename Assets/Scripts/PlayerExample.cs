using UnityEngine;


    public class PlayerExample : MonoBehaviour
    {
        
        private int health = 10;
        [ContextMenuItem("Choose Random DPS", "RanomiseDPS")]
        public int damagePerSecond = 5;
        [ContextMenu("TakeDamage")]
        public void TakeDamage(){
            health--;
        }

        private void RanomiseDPS()
        {
            damagePerSecond = UnityEngine.Random.Range(1, 10);
        }
    }
