using BoDi;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.Tracing;

namespace NUnit3Tracing.SpecFlowPlugin
{
    public class NUnit3TracingPlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            runtimePluginEvents.CustomizeScenarioDependencies += (sender, args) => { RegisterDependencies(args.ObjectContainer); };
        }

        private void RegisterDependencies(ObjectContainer container)
        {
            container.RegisterTypeAs<NUnit3TraceListener, ITraceListener>();
        }
    }
}
