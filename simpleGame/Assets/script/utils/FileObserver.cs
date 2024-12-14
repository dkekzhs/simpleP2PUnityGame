using System;
using System.IO;

public class FileObserver
{
    private string filePath;
    private PlayerData observedData;

    public FileObserver(string filePath, PlayerData playerData)
    {
        this.filePath = filePath;
        this.observedData = playerData;
    }

    public void OnDataChanged()
    {
        observedData.SaveToFile(filePath);
    }

    public void UpdateScore(int newScore)
    {
        observedData.score = newScore;
        OnDataChanged();
    }

    public void UpdateLevel(int newLevel)
    {
        observedData.level = newLevel;
        OnDataChanged();
    }
}
