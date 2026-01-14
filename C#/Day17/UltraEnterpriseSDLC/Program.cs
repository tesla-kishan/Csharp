using System;
using System.Collections.Generic;
using System.Linq;

/*
===========================================================
PROJECT: Ultra Enterprise SDLC Lifecycle Orchestrator
FILE  : Single-file complete implementation
PURPOSE:
- Simulates enterprise SDLC lifecycle
- Tracks requirements, work items, dependencies
- Handles execution, deployment, rollback
- Maintains audit logs and quality metrics
===========================================================
*/

namespace UltraEnterpriseSDLC
{
    // =====================================================
    // ENUM: RiskLevel
    // PURPOSE:
    // Represents business risk of a requirement
    // =====================================================
    public enum RiskLevel
    {
        Low,
        Medium,
        High,
        Critical
    }

    // =====================================================
    // ENUM: SDLCStage
    // PURPOSE:
    // Defines strict SDLC lifecycle progression
    // Integer order matters for stage advancement
    // =====================================================
    public enum SDLCStage
    {
        Backlog = 0,
        Requirement = 1,
        Design = 2,
        Development = 3,
        CodeReview = 4,
        Testing = 5,
        UAT = 6,
        Deployment = 7,
        Maintenance = 8
    }

    // =====================================================
    // CLASS: Requirement
    // PURPOSE:
    // Represents a business requirement
    // Sealed → cannot be inherited
    // =====================================================
    public sealed class Requirement
    {
        // Unique identifier
        public int Id { get; }

        // Requirement description
        public string Title { get; }

        // Risk classification
        public RiskLevel Risk { get; }

        // Constructor initializes immutable properties
        public Requirement(int id, string title, RiskLevel risk)
        {
            Id = id;
            Title = title;
            Risk = risk;
        }
    }

    // =====================================================
    // CLASS: WorkItem
    // PURPOSE:
    // Represents executable SDLC work
    // =====================================================
    public sealed class WorkItem
    {
        // Unique WorkItem ID
        public int Id { get; }

        // Name of the work item
        public string Name { get; }

        // Current SDLC stage (can change)
        public SDLCStage Stage { get; set; }

        // IDs of dependent work items
        // HashSet prevents duplicates automatically
        public HashSet<int> DependencyIds { get; }

        // Constructor
        public WorkItem(int id, string name, SDLCStage stage)
        {
            Id = id;
            Name = name;
            Stage = stage;
            DependencyIds = new HashSet<int>();
        }
    }

    // =====================================================
    // CLASS: BuildSnapshot
    // PURPOSE:
    // Stores deployment snapshot for rollback
    // =====================================================
    public sealed class BuildSnapshot
    {
        // Release version
        public string Version { get; }

        // Deployment timestamp
        public DateTime Timestamp { get; }

        public BuildSnapshot(string version)
        {
            Version = version;
            Timestamp = DateTime.Now;
        }
    }

    // =====================================================
    // CLASS: AuditLog
    // PURPOSE:
    // Immutable audit trail entry
    // =====================================================
    public sealed class AuditLog
    {
        // Time of action
        public DateTime Time { get; }

        // Description of action
        public string Action { get; }

        public AuditLog(string action)
        {
            Time = DateTime.Now;
            Action = action;
        }
    }

    // =====================================================
    // CLASS: QualityMetric
    // PURPOSE:
    // Stores quality score of a release
    // =====================================================
    public sealed class QualityMetric
    {
        public string Name { get; }
        public double Score { get; }

        public QualityMetric(string name, double score)
        {
            Name = name;
            Score = score;
        }
    }

    // =====================================================
    // CORE CLASS: EnterpriseSDLCEngine
    // PURPOSE:
    // Manages entire SDLC lifecycle
    // =====================================================
    public class EnterpriseSDLCEngine
    {
        // Stores requirements
        private List<Requirement> _requirements;

        // Fast lookup of work items by ID
        private Dictionary<int, WorkItem> _workItemRegistry;

        // Tracks work items by SDLC stage
        private SortedDictionary<SDLCStage, List<WorkItem>> _stageBoard;

        // FIFO execution queue
        private Queue<WorkItem> _executionQueue;

        // LIFO rollback history
        private Stack<BuildSnapshot> _rollbackStack;

        // Unique test suites
        private HashSet<string> _uniqueTestSuites;

        // Immutable audit ledger
        private LinkedList<AuditLog> _auditLedger;

        // Release quality ranking
        private SortedList<double, QualityMetric> _releaseScoreboard;

        // Counters for IDs
        private int _requirementCounter;
        private int _workItemCounter;

        // =================================================
        // CONSTRUCTOR
        // Initializes all enterprise collections
        // =================================================
        public EnterpriseSDLCEngine()
        {
            _requirements = new List<Requirement>();
            _workItemRegistry = new Dictionary<int, WorkItem>();
            _stageBoard = new SortedDictionary<SDLCStage, List<WorkItem>>();

            // Create empty list for every SDLC stage
            foreach (SDLCStage stage in Enum.GetValues(typeof(SDLCStage)))
                _stageBoard[stage] = new List<WorkItem>();

            _executionQueue = new Queue<WorkItem>();
            _rollbackStack = new Stack<BuildSnapshot>();
            _uniqueTestSuites = new HashSet<string>();
            _auditLedger = new LinkedList<AuditLog>();
            _releaseScoreboard = new SortedList<double, QualityMetric>();
        }

        // =================================================
        // METHOD: AddRequirement
        // Adds business requirement and logs it
        // =================================================
        public void AddRequirement(string title, RiskLevel risk)
        {
            var req = new Requirement(_requirementCounter++, title, risk);
            _requirements.Add(req);
            _auditLedger.AddLast(new AuditLog(
                $"Requirement added: {title}, Risk: {risk}"
            ));
        }

        // =================================================
        // METHOD: CreateWorkItem
        // Creates and registers a work item
        // =================================================
        public WorkItem CreateWorkItem(string name, SDLCStage stage)
        {
            var item = new WorkItem(_workItemCounter++, name, stage);
            _workItemRegistry[item.Id] = item;
            _stageBoard[stage].Add(item);

            _auditLedger.AddLast(new AuditLog(
                $"WorkItem created: {name}, Stage: {stage}"
            ));

            return item;
        }

        // =================================================
        // METHOD: AddDependency
        // Adds dependency between work items
        // =================================================
        public void AddDependency(int workItemId, int dependsOnId)
        {
            if (_workItemRegistry.ContainsKey(workItemId) &&
                _workItemRegistry.ContainsKey(dependsOnId))
            {
                _workItemRegistry[workItemId].DependencyIds.Add(dependsOnId);

                _auditLedger.AddLast(new AuditLog(
                    $"Dependency added: {workItemId} depends on {dependsOnId}"
                ));
            }
        }

        // =================================================
        // METHOD: PlanStage
        // Plans execution respecting dependencies
        // =================================================
        public void PlanStage(SDLCStage stage)
        {
            var eligibleItems =
                _stageBoard[stage]
                .Where(item =>
                    item.DependencyIds.All(depId =>
                        _workItemRegistry[depId].Stage > stage))
                .ToList();

            foreach (var item in eligibleItems)
                _executionQueue.Enqueue(item);

            _auditLedger.AddLast(new AuditLog(
                $"Stage planned: {stage}"
            ));
        }

        // =================================================
        // METHOD: ExecuteNext
        // Executes next work item
        // =================================================
        public void ExecuteNext()
        {
            if (_executionQueue.Count == 0)
                return;

            var item = _executionQueue.Dequeue();
            var oldStage = item.Stage;

            // Advance to next SDLC stage
            item.Stage = (SDLCStage)((int)item.Stage + 1);

            _stageBoard[oldStage].Remove(item);
            _stageBoard[item.Stage].Add(item);

            _auditLedger.AddLast(new AuditLog(
                $"Executed WorkItem {item.Id}: {oldStage} → {item.Stage}"
            ));
        }

        // =================================================
        // METHOD: RegisterTestSuite
        // Registers unique test suite
        // =================================================
        public void RegisterTestSuite(string suiteId)
        {
            _uniqueTestSuites.Add(suiteId);

            _auditLedger.AddLast(new AuditLog(
                $"Test suite registered: {suiteId}"
            ));
        }

        // =================================================
        // METHOD: DeployRelease
        // Records deployment snapshot
        // =================================================
        public void DeployRelease(string version)
        {
            _rollbackStack.Push(new BuildSnapshot(version));

            _auditLedger.AddLast(new AuditLog(
                $"Release deployed: {version}"
            ));
        }

        // =================================================
        // METHOD: RollbackRelease
        // Rolls back last deployed release
        // =================================================
        public void RollbackRelease()
        {
            if (_rollbackStack.Count == 0)
                return;

            var snap = _rollbackStack.Pop();

            _auditLedger.AddLast(new AuditLog(
                $"Rollback executed to version: {snap.Version}"
            ));
        }

        // =================================================
        // METHOD: RecordQualityMetric
        // Stores release quality score
        // =================================================
        public void RecordQualityMetric(string metricName, double score)
        {
            if (!_releaseScoreboard.ContainsKey(score))
                _releaseScoreboard.Add(score,
                    new QualityMetric(metricName, score));
        }

        // =================================================
        // METHOD: PrintAuditLedger
        // Displays all audit logs
        // =================================================
        public void PrintAuditLedger()
        {
            Console.WriteLine("\n--- AUDIT LEDGER ---");
            foreach (var log in _auditLedger)
                Console.WriteLine($"{log.Time} | {log.Action}");
        }

        // =================================================
        // METHOD: PrintReleaseScoreboard
        // Displays quality metrics in descending order
        // =================================================
        public void PrintReleaseScoreboard()
        {
            Console.WriteLine("\n--- RELEASE QUALITY SCOREBOARD ---");
            foreach (var entry in _releaseScoreboard.Reverse())
                Console.WriteLine(
                    $"{entry.Value.Name} : {entry.Key:F2}"
                );
        }
    }

    // =====================================================
    // MAIN PROGRAM
    // PURPOSE:
    // Demonstrates full SDLC lifecycle
    // =====================================================
    class Program
    {
        static void Main()
        {
            var engine = new EnterpriseSDLCEngine();

            // Step 1: Add requirements
            engine.AddRequirement("Single Sign-On", RiskLevel.High);
            engine.AddRequirement("Fraud Detection", RiskLevel.Critical);

            // Step 2: Create work items
            var design = engine.CreateWorkItem("SSO Design", SDLCStage.Design);
            var dev = engine.CreateWorkItem("SSO Development", SDLCStage.Development);
            var test = engine.CreateWorkItem("SSO Testing", SDLCStage.Testing);

            // Step 3: Add dependencies
            engine.AddDependency(dev.Id, design.Id);
            engine.AddDependency(test.Id, dev.Id);

            // Step 4: Register test suites
            engine.RegisterTestSuite("SSO-Regression");
            engine.RegisterTestSuite("SSO-Security");

            // Step 5: Plan and execute
            engine.PlanStage(SDLCStage.Design);
            engine.ExecuteNext();
            engine.ExecuteNext();

            // Step 6: Deploy release
            engine.DeployRelease("v3.4.1");

            // Step 7: Record quality metrics
            engine.RecordQualityMetric("Code Coverage", 91.7);
            engine.RecordQualityMetric("Security Score", 97.3);

            // Step 8: Rollback release
            engine.RollbackRelease();

            // Step 9: Print reports
            engine.PrintAuditLedger();
            engine.PrintReleaseScoreboard();
        }
    }
}
