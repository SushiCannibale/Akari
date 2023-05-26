public interface IPersistentData
{
    void LoadFrom(GameData data);
    void SaveTo(GameData data);
}