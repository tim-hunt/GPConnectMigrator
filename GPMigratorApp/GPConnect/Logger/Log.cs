using System;
using System.Collections.Generic;
using GPConnect.Provider.AcceptanceTests.Helpers;
using System.IO;
using GPConnect.Provider.AcceptanceTests.Context;

namespace GPConnect.Provider.AcceptanceTests.Logger
{
    using Hl7.Fhir.Model;
    using LogBuffer = List<string>;

 
    internal static class Log
    {

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format);
        }

        internal static void WriteLine(Resource fhirResponseResource)
        {
            throw new NotImplementedException();
        }

        internal static void WriteLine(ResourceType resourceType)
        {
            throw new NotImplementedException();
        }

        internal static void WriteLine(Func<string> toString)
        {
            throw new NotImplementedException();
        }

        internal static void WriteLine(Bundle.EntryComponent entry)
        {
            throw new NotImplementedException();
        }
        
        public static void HandleScenarioFailure()
        {
      
        }

        private static void DumpLog()
        {
         
        }


        public static void DumpLogToFile()
        {
         
        }

        private const string ScenarioLogKey = "ScenarioLog";
    }
}
