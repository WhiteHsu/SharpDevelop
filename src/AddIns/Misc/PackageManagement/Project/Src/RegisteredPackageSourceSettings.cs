﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using NuGet;

namespace ICSharpCode.PackageManagement
{
	public class RegisteredPackageSourceSettings
	{
		public static readonly string PackageSourcesSectionName = "packageSources";
		public static readonly string ActivePackageSourceSectionName = "activePackageSource";
		
		ISettings settings;
		RegisteredPackageSources packageSources;
		PackageSource activePackageSource;
		
		public RegisteredPackageSourceSettings(ISettings settings)
		{
			this.settings = settings;
			ReadActivePackageSource();
		}
		
		void ReadActivePackageSource()
		{
			IList<KeyValuePair<string, string>> packageSources = settings.GetValues(ActivePackageSourceSectionName);
			activePackageSource = PackageSourceConverter.ConvertFromFirstKeyValuePair(packageSources);
		}
		
		public RegisteredPackageSources PackageSources {
			get {
				if (packageSources == null) {
					ReadPackageSources();
				}
				return packageSources;
			}
		}
		
		void ReadPackageSources()
		{
			var savedPackageSources = GetPackageSourcesFromSettings();
			packageSources = new RegisteredPackageSources(savedPackageSources);
			packageSources.CollectionChanged += PackageSourcesChanged;
		}
		
		IEnumerable<PackageSource> GetPackageSourcesFromSettings()
		{
			IList<KeyValuePair<string, string>> savedPackageSources = settings.GetValues(PackageSourcesSectionName);
			return PackageSourceConverter.ConvertFromKeyValuePairs(savedPackageSources);
		}
		
		void PackageSourcesChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			UpdatePackageSourceSettingsWithChanges();
		}
		
		void UpdatePackageSourceSettingsWithChanges()
		{
			var newPackageSourceSettings = GetSettingsFromPackageSources();
			SavePackageSourceSettings(newPackageSourceSettings);
		}
		
		IList<KeyValuePair<string, string>> GetSettingsFromPackageSources()
		{
			return PackageSourceConverter.ConvertToKeyValuePairList(packageSources);
		}
		
		KeyValuePair<string, string> CreateKeyValuePairFromPackageSource(PackageSource source)
		{
			return new KeyValuePair<string, string>(source.Name, source.Source);
		}
		
		void SavePackageSourceSettings(IList<KeyValuePair<string, string>> newPackageSourceSettings)
		{
			settings.DeleteSection(PackageSourcesSectionName);
			settings.SetValues(PackageSourcesSectionName, newPackageSourceSettings);
		}
		
		public PackageSource ActivePackageSource {
			get {
				if (PackageSources.Contains(activePackageSource)) {
					return activePackageSource;
				}
				return null;
			}
			set {
				activePackageSource = value;
				if (activePackageSource == null) {
					RemoveActivePackageSourceSetting();
				} else {
					UpdateActivePackageSourceSetting();
				}
			}
		}
		
		void RemoveActivePackageSourceSetting()
		{
			settings.DeleteSection(ActivePackageSourceSectionName);
		}
		
		void UpdateActivePackageSourceSetting()
		{
			RemoveActivePackageSourceSetting();
			
			var activePackageSourceSetting = PackageSourceConverter.ConvertToKeyValuePair(activePackageSource);
			SaveActivePackageSourceSetting(activePackageSourceSetting);
		}
		
		void SaveActivePackageSourceSetting(KeyValuePair<string, string> activePackageSource)
		{
			settings.SetValue(ActivePackageSourceSectionName, activePackageSource.Key, activePackageSource.Value);
		}
	}
}
