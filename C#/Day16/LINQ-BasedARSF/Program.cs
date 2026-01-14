

namespace AutonomousRobot.AI
{
    class Program
    {
        static void Main()
        {
            // ---------- SAMPLE SENSOR HISTORY ----------
            List<SensorReading> sensorHistory = new List<SensorReading>
            {
                new SensorReading{ SensorId=1, Type="Distance", Value=0.8, Confidence=0.9, Timestamp=DateTime.Now.AddSeconds(-5)},
                new SensorReading{ SensorId=2, Type="Battery", Value=18, Confidence=0.8, Timestamp=DateTime.Now.AddSeconds(-4)},
                new SensorReading{ SensorId=3, Type="Temperature", Value=92, Confidence=0.7, Timestamp=DateTime.Now.AddSeconds(-3)},
                new SensorReading{ SensorId=4, Type="Vibration", Value=8.2, Confidence=0.6, Timestamp=DateTime.Now.AddSeconds(-2)},
                new SensorReading{ SensorId=5, Type="Battery", Value=75, Confidence=0.9, Timestamp=DateTime.Now.AddSeconds(-1)},
                new SensorReading{ SensorId=6, Type="Distance", Value=2.5, Confidence=0.5, Timestamp=DateTime.Now }
            };

            DateTime fromTime = DateTime.Now.AddSeconds(-10);

            DecisionEngine engine = new DecisionEngine();

            // ===== EXECUTION ORDER STRICTLY FOLLOWED =====

            var recentReadings = engine.GetRecentReadings(sensorHistory, fromTime);

            var batteryCritical = engine.IsBatteryCritical(recentReadings);

            var nearestObstacle = engine.GetNearestObstacleDistance(recentReadings);

            var temperatureSafe = engine.IsTemperatureSafe(recentReadings);

            var avgVibration = engine.GetAverageVibration(recentReadings);

            var sensorHealth = engine.CalculateSensorHealth(sensorHistory);

            var faultySensors = engine.DetectFaultySensors(sensorHistory);

            var batteryDrainingFast = engine.IsBatteryDrainingFast(sensorHistory);

            var weightedDistance = engine.GetWeightedDistance(recentReadings);

            var action = engine.DecideRobotAction(recentReadings, sensorHistory);

            // ===== FINAL OUTPUT =====
            Console.WriteLine("Robot Action: " + action);
        }
    }
}
