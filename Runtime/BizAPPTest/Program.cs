using System;
using System.Collections;
using System.Configuration;
using BizAPP.Common;
using BizAPP.Runtime.Core;
using BizAPP.Runtime.Core.Service.Authentication;

namespace BizAPPTest
{
	class Program
	{
		static void Main( string[ ] args )
		{
			var settings = ConfigurationManager.AppSettings;
			string enterprise = settings[ "enterprise" ];
			string user = settings[ "username" ];
			string pwd = settings[ "password" ];
			var rb = RuntimeBootstrap.GetTheOnlyBootstrap( settings[ "hosting" ], settings[ "registry" ] );

			Hashtable creds = new Hashtable( 4 );
			creds.Add( AuthenticationParameters.ENTERPRISENAME, enterprise );
			creds.Add( AuthenticationParameters.REALM, "BizAPP" );
			creds.Add( AuthenticationParameters.USERNAME, user );
			creds.Add( AuthenticationParameters.PASSWORD, pwd );

			try
			{
				using ( var session = rb.GetSession( creds, NetworkInformation.Current, BizAPP.Runtime.Core.Service.Session.SessionMode.Client ) )
				{
					// do your stuff here
				}
			}
			catch ( Exception ex )
			{
				Console.WriteLine( ExceptionUtils.CaptureCompleteException( ex ) );
			}
		}
	}
}
