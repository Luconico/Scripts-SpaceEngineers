public Program()
{
    Runtime.UpdateFrequency = UpdateFrequency.Update10;
}


public void Main(string argument, UpdateType updateSource)
{
    List<IMySensorBlock> sensors = new List<IMySensorBlock>();
    GridTerminalSystem.GetBlocksOfType(sensors, sensor => sensor.CustomName.Contains("SensorPuerta"));

    foreach (var sensor in sensors)
    {
        bool isDetected = sensor.IsActive;
        string doorName = sensor.CustomName.Replace("SensorPuerta", "Puerta");
        var door = GridTerminalSystem.GetBlockWithName(doorName) as IMyDoor;

        if (door != null)
        {
            if (isDetected && door.Status != DoorStatus.Open && door.Status != DoorStatus.Opening)
            {
                door.OpenDoor();
                Echo("Abriendo: " + door.CustomName);
            }
            else if (!isDetected && door.Status != DoorStatus.Closed && door.Status != DoorStatus.Closing)
            {
                door.CloseDoor();
                Echo("Cerrando: " + door.CustomName);
            }
        }
        else
        {
            Echo("Puerta no encontrada para el sensor: " + sensor.CustomName);
        }
    }
}