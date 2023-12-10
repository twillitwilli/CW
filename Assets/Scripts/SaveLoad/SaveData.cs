using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string playerName;
    public float[] playerPosition;

    public int
        saveFile,
        saveLocation;

    public bool[] chestsObtained;
    public bool[] itemsObtained;

    public bool
        returningPlayer,
        randomizerMode;

    // Player Stats

    public int
        maxHealth,
        currentHeartPiece,
        currentGold,
        maxGold,
        maxMana,
        currentMagicKnives,
        maxMagicKnives;

    // Player Progression

    public bool
        hasWeapon,
        hasSpear,
        hasScythe,
        hasTheForgottenScythe,
        hasMagicGlove,
        hasItem,
        hasMagicKnifePouch,
        hasFireCrystal,
        hasGhostStaff,
        hasBookOfTruth,
        hasGravityCrystal,
        hasPortalCrystal,
        hasMagicHourglass;
}
