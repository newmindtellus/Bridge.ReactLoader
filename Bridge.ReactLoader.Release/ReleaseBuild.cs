using Bridge;

namespace BridgeReactRelease
{
	// We don't actually need this code to do anything when it's executed, it is only required so that MsBuild can see an obvious reference from the application to this assembly and so
	// doesn't try to remove the reference (if it did so then the library JavaScript files wouldn't end up in the application - we rely upon MsBuild performing this optimisation, though,
	// to ensure that only the Debug OR Release version of the library gets included in the final project). We use [External] and [Template] so that this file doesn't genereate any JS
	// content and so that the calling code doesn't try to all it when it's translated into JS.
	[External]
	public static class ReleaseBuild
	{
		/// <summary>
		/// This method exists only to allow the application to have a direct reference to the assembly (the application should have a reference in its code to either the Debug or
		/// Release assembly - although both assemblies will be added as references to the application project, MsBuild will remove the reference that isn't directly referenced
		/// by code)
		/// </summary>
		[Template("/* Including React Production Build via Bridge.ReactLoader */")]
		public extern static void Include();
	}
}
