using Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private static PlayerData _init;
    public static PlayerData init
    {
        get
        {
            if (_init == null)
                if (PlayerPrefs.HasKey("PlayerData"))
                {
                    _init = JsonConvert.DeserializeObject<PlayerData>(PlayerPrefs.GetString("PlayerData"), new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });
                }
                else
                    _init = new PlayerData();
            return _init;
        }
    }
    public void Save()
    {
        PlayerPrefs.SetString("PlayerData", JsonConvert.SerializeObject(this, new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
            Converters = { new StringEnumConverter() }
        }));
    }

    public PlayerData()
    {
        this.numericalManaqer = new NumericalManaqer();
    }

    public NumericalManaqer numericalManaqer { get; set; }
}