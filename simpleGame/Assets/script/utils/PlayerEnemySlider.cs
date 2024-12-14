using UnityEngine;
using UnityEngine.UI;

public class PlayerEnemySlider : MonoBehaviour
{
    public Slider playerSlider; 
    public Slider enemySlider;  
    public PlayerSetting playerSetting;

    public void OnPlayerSliderChanged()
    {
        playerSetting.SetMaxPlayers((int)playerSlider.value);
    }

    public void OnEnemySliderChanged()
    {
        playerSetting.SetMaxEnemies((int)enemySlider.value);
    }
}
