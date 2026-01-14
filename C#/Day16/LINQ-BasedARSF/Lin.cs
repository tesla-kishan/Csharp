using System;
using System.Collections.Generic;
using System.Linq;

namespace AutonomousRobot.AI
{
    // ===== SensorReading CLASS =====
    public class SensorReading
    {
        public int SensorId { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
        public double Confidence { get; set; }
    }

    // ===== RobotAction ENUM =====
    public enum RobotAction
    {
        Stop,
        SlowDown,
        Reroute,
        Continue
    }

    // ===== DecisionEngine CLASS =====
    public class DecisionEngine
    {
        // Task 1
        public List<SensorReading> GetRecentReadings(List<SensorReading> sensorHistory, DateTime fromTime)
        {
            return sensorHistory
                .Where(r => r.Timestamp >= fromTime)
                .ToList();
        }

        // Task 2
        public bool IsBatteryCritical(List<SensorReading> readings)
        {
            return readings.Any(r => r.Type == "Battery" && r.Value < 20);
        }

        // Task 3
        public double GetNearestObstacleDistance(List<SensorReading> readings)
        {
            var distances = readings.Where(r => r.Type == "Distance").Select(r => r.Value);
            return distances.Any() ? distances.Min() : double.MaxValue;
        }

        // Task 4
        public bool IsTemperatureSafe(List<SensorReading> readings)
        {
            return readings
                .Where(r => r.Type == "Temperature")
                .All(r => r.Value < 90);
        }

        // Task 5
        public double GetAverageVibration(List<SensorReading> readings)
        {
            var vibrations = readings.Where(r => r.Type == "Vibration").Select(r => r.Value);
            return vibrations.Any() ? vibrations.Average() : 0;
        }

        // Task 6
        public Dictionary<string, double> CalculateSensorHealth(List<SensorReading> sensorHistory)
        {
            return sensorHistory
                .GroupBy(r => r.Type)
                .ToDictionary(g => g.Key, g => g.Average(r => r.Confidence));
        }

        // Task 7
        public List<string> DetectFaultySensors(List<SensorReading> sensorHistory)
        {
            return sensorHistory
                .GroupBy(r => r.Type)
                .Where(g => g.Count(r => r.Confidence < 0.4) > 2)
                .Select(g => g.Key)
                .ToList();
        }

        // Task 8
        public bool IsBatteryDrainingFast(List<SensorReading> sensorHistory)
        {
            var batteryReadings = sensorHistory
                .Where(r => r.Type == "Battery")
                .OrderBy(r => r.Timestamp)
                .Select(r => r.Value)
                .ToList();

            return batteryReadings
                .Zip(batteryReadings.Skip(1), (a, b) => b < a)
                .All(x => x);
        }

        // Task 9
        public double GetWeightedDistance(List<SensorReading> readings)
        {
            var distanceReadings = readings.Where(r => r.Type == "Distance");

            double totalConfidence = distanceReadings.Sum(r => r.Confidence);
            if (totalConfidence == 0) return double.MaxValue;

            double weightedSum = distanceReadings.Sum(r => r.Value * r.Confidence);
            return weightedSum / totalConfidence;
        }

        // Task 10
        public RobotAction DecideRobotAction(List<SensorReading> recentReadings, List<SensorReading> sensorHistory)
        {
            if (IsBatteryCritical(recentReadings))
                return RobotAction.Stop;

            if (GetNearestObstacleDistance(recentReadings) < 1.0)
                return RobotAction.Reroute;

            if (!IsTemperatureSafe(recentReadings) || GetAverageVibration(recentReadings) > 7.0)
                return RobotAction.SlowDown;

            return RobotAction.Continue;
        }
    }
}