﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using ICSharpCode.AddInManager2.Model;
using ICSharpCode.AddInManager2.Model.Interfaces;

namespace ICSharpCode.AddInManager2
{
    /// <summary>
    /// Container for public services of AddInManager AddIn.
    /// </summary>
    public class AddInManagerServices
    {
    	private class AddInManagerServiceContainer : IAddInManagerServices
    	{
			public IAddInManagerEvents Events
			{
				get;
				set;
			}
    		
			public IPackageRepositories Repositories
			{
				get;
				set;
			}
    		
			public IAddInSetup Setup
			{
				get;
				set;
			}
    		
			public INuGetPackageManager NuGet
			{
				get;
				set;
			}
    	}
    	
    	private static AddInManagerServiceContainer _container;
    	
        static AddInManagerServices()
		{
        	_container = new AddInManagerServiceContainer();
			_container.Events = new AddInManagerEvents();
			_container.Repositories = new PackageRepositories();
			_container.NuGet = new NuGetPackageManager(_container.Repositories, _container.Events);
			_container.Setup = new AddInSetup(_container.Events, _container.NuGet);
		}

        public static IAddInManagerEvents Events
        {
            get
            {
                return _container.Events;
            }
        }

        public static IPackageRepositories Repositories
        {
            get
            {
                return _container.Repositories;
            }
        }

        public static IAddInSetup Setup
        {
            get
            {
                return _container.Setup;
            }
        }

        public static INuGetPackageManager NuGet
        {
            get
            {
                return _container.NuGet;
            }
        }
        
        public static IAddInManagerServices Services
        {
        	get
        	{
        		return _container;
        	}
        }
    }
}