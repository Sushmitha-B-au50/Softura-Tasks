using React;
using JavaScriptEngineSwitcher.V8;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MVCUsingReact.ReactConfig), "Configure")]

namespace MVCUsingReact
{
	public static class ReactConfig
	{
		public static void Configure()
		{
			JavaScriptEngineSwitcher.Core.JsEngineSwitcher.Current.DefaultEngineName = V8JsEngine.EngineName;
			JavaScriptEngineSwitcher.Core.JsEngineSwitcher.Current.EngineFactories.AddV8();
		}
	}
}