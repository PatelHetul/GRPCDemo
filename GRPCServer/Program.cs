﻿using Grpc.Core;
using Grpcdemoproject;
using System;

namespace GRPCServer
{
	class Program
	{
		static void Main(string[] args)
		{
			const int Port = 50052;

			var features = RouteGuideUtil.ParseFeatures(RouteGuideUtil.DefaultFeaturesFile);

			Server server = new Server
			{
				Services = { RouteGuide.BindService(new RouteGuideImpl(features)) },
				Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
			};
			server.Start();

			Console.WriteLine("RouteGuide server listening on port " + Port);
			Console.WriteLine("Press any key to stop the server...");
			Console.ReadKey();

			server.ShutdownAsync().Wait();
		}
	}
}
