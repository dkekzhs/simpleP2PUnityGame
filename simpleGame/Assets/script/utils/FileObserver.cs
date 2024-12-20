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

}
