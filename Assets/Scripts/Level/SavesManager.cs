using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavesManager : MonoBehaviour
{
    [SerializeField] string fileName;
    [SerializeField] GameObject tower;
    [SerializeField] Sprite[] shapes;
    string Path { get { return Application.persistentDataPath + fileName; } }
    private void Start()
    {
        if (File.Exists(Path))
            LoadGame();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SaveGame();
            SceneManager.LoadScene("Menu");
        }
    }
    public void SaveGame()
    {
        var tmp = new SaveData();
        tmp.money = PlayerMoney.instance.Money;
        tmp.HP = PlayerHealth.instance.Health;
        tmp.waveNumber = LevelManager.instance.Wave;
        tmp.nextWave = WaveManager.wave;
        var towers = GameObject.FindGameObjectsWithTag("Tower");
        tmp.towers = new TowerSaveData[towers.Length];
        for(int i = 0;i<towers.Length;i++)
            tmp.towers[i] = new TowerSaveData(towers[i].GetComponent<TowerUpgrade>());
        File.WriteAllText(Path, JsonUtility.ToJson(tmp,Application.isEditor));
    }
    public void LoadGame()
    {
        var data = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path));
        PlayerMoney.instance.Money = data.money;
        PlayerHealth.instance.Health = data.HP;
        WaveManager.wave = data.nextWave;
        LevelManager.instance.Wave = data.waveNumber;
        for (int i = 0; i < data.towers.Length; i++)
        {
            TowerUpgrade upgrade = Instantiate(tower, data.towers[i].position, Quaternion.identity).GetComponent<TowerUpgrade>();
            upgrade.GetComponent<TowerSetupController>().Set(true);
            var sp = upgrade.GetComponent<SpriteRenderer>();
            sp.sprite = shapes[(int)data.towers[i].shape];
            sp.color = ColorConverter.ToColor(data.towers[i].effect.type);

            upgrade.data.Shape = data.towers[i].shape;
            upgrade.data.Effect = data.towers[i].effect;
            upgrade.data.Damage = data.towers[i].damage;
            upgrade.data.Reload = data.towers[i].reload;
            upgrade.data.BulletSpeed = data.towers[i].bulletSpeed;
            upgrade.data.Range = data.towers[i].range;
            upgrade.data.smart = data.towers[i].isSmart;
            upgrade.data.aim.aimType = data.towers[i].aimType;
            
            upgrade.transform.GetChild(1).localScale = Vector3.one * upgrade.data.Range;

            upgrade.prices = data.towers[i].prices;
            upgrade.Stages = data.towers[i].stages;
            upgrade.ColorUpdatePrice = data.towers[i].colorUpdatePrice;
            upgrade.TowerCost = data.towers[i].towerCost;
        }
    }
}
[System.Serializable]
public class TowerSaveData
{
    public Vector3 position;

    public Shapes shape;
    public Effect effect;
    public float range, damage, reload, bulletSpeed;
    public bool isSmart;
    public Targeting aimType;

    public int[] stages;
    public float[] prices;
    public float colorUpdatePrice;
    public float towerCost;
    public TowerSaveData(TowerUpgrade upgrade)
    {
        position = upgrade.transform.position;
        shape = upgrade.data.Shape;
        effect = upgrade.data.Effect;
        range = upgrade.data.Range;
        damage = upgrade.data.Damage;
        reload = upgrade.data.Reload;
        bulletSpeed = upgrade.data.BulletSpeed;
        isSmart = upgrade.data.smart;
        aimType = upgrade.data.aim.aimType;
        stages = upgrade.Stages;
        prices = upgrade.prices;
        colorUpdatePrice = upgrade.ColorUpdatePrice;
        towerCost = upgrade.TowerCost;
    }
    public TowerSaveData()
    { }
}
[System.Serializable]
public class SaveData
{
    public float money;
    public int HP;

    public int waveNumber;
    public WaveData nextWave;

    public TowerSaveData[] towers;
}

