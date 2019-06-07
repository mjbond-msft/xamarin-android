using System;
using System.IO;

namespace Xamarin.Android.Prepare
{
	class AndroidToolchainComponent : AppObject
	{
		public string Name                { get; }
		public string DestDir             { get; }
		public Uri RelativeUrl            { get; }
		public bool IsMultiVersion        { get; }
		public bool NoSubdirectory        { get; }
		public string ExpectedPkgRevision { get; }

		public AndroidToolchainComponent (string name, string destDir, Uri relativeUrl = null, bool isMultiVersion = false, bool noSubdirectory = false, string expectedPkgRevision = null)
		{
			if (String.IsNullOrEmpty (name))
				throw new ArgumentException ("must not be null or empty", nameof (name));
			if (String.IsNullOrEmpty (destDir))
				throw new ArgumentException ("must not be null or empty", nameof (destDir));

			Name = name;
			DestDir = destDir;
			RelativeUrl = relativeUrl;
			IsMultiVersion = isMultiVersion;
			NoSubdirectory = noSubdirectory;
			ExpectedPkgRevision = expectedPkgRevision;
		}
	}

	class AndroidPlatformComponent : AndroidToolchainComponent
	{
		public AndroidPlatformComponent (string name, string apiLevel)
			: base (name, Path.Combine ("platforms", $"android-{apiLevel}"))
		{}
	}
}
